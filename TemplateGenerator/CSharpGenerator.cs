using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace TemplateGenerator;

internal partial class CSharpGenerator : GeneratorBase
{
    [GeneratedRegex(@"^(?<OutputType>\S+) (?<MethodName>\S+?)\s*\((?<Arguments>.+)?\)$")]
    private static partial Regex SignatureRegex();

    [GeneratedRegex(@"\r\nInput: (?<Input>(.|\r\n)+?)\r\nOutput: (?<Output>.+?)($|\r\n)")]
    private static partial Regex ExamplesRegex();

    [UsedImplicitly]
    public JsonObject[] Examples { get; set; } = [];

    [UsedImplicitly]
    public string MethodName { get; private set; } = string.Empty;

    [UsedImplicitly]
    public Argument[] InputArguments { get; private set; } = [];

    [UsedImplicitly]
    public Argument OutputArgument { get; private set; } = new();

    [UsedImplicitly]
    public string InvokeSolutionCode { get; private set; } = string.Empty;

    [UsedImplicitly]
    public IEnumerable<Argument> AllArguments => InputArguments.Append(OutputArgument);

    public override bool CanGenerate() => SignatureRegex().IsMatch(Signature);

    public override void Generate(string? examplesStr)
    {
        var signatureMatch = SignatureRegex().Match(Signature);
        var outputType = signatureMatch.Groups["OutputType"].Value;
        MethodName = signatureMatch.Groups["MethodName"].Value;
        InputArguments = signatureMatch.Groups["Arguments"].Value.Split(", ").Select(argumentStr =>
        {
            var parts = argumentStr.Split(' ');

            if (parts.Length < 2)
            {
                throw new InvalidOperationException($"Invalid argument format: '{argumentStr}'. Expected 'type name'.");
            }

            var originalType = parts[0];
            var jsonName = parts[1];
            return Argument.Create(originalType, jsonName);
        }).ToArray();

        OutputArgument = Argument.Create(outputType, "output");

        InvokeSolutionCode = GenerateTemplate("""
            solution.{{ MethodName }}(
            {{- for argument in InputArguments -}}
                {{- argument.TestCasePropertyCode }}{{ if !for.last; ', '; end -}}
            {{- end -}}
            )
            """);

        examplesStr ??= ConsoleHelper.ReadMultiline("Examples");
        Examples = ExamplesRegex().Matches(examplesStr).Select(match =>
        {
            var input = match.Groups["Input"].Value.Replace(" = ", ": ");
            var output = match.Groups["Output"].Value;
            var json = $"{{ {input}, output: {output} }}";
            return (JsonObject)JsonNode.Parse(json)!;
        }).ToArray();

        GenerateFile("ISolution.cs", """
            {{ Namespace }}

            [PublicAPI]
            public interface ISolution
            {
                {{ Signature }};
            }
            """);

        GenerateFile("Solution1.cs", """
            {{ Namespace }}

            /// <summary>
            /// TODO url
            /// </summary>
            [UsedImplicitly]
            public class Solution1 : ISolution
            {
                public {{ Signature }}
                {
                    throw new NotImplementedException();
                }
            }
            """);

        GenerateFile("Tests.cs", """
            {{ Namespace }}

            [UsedImplicitly]
            public class Tests : TestsBase<ISolution, Tests.TestCase>
            {
                protected override void TestCore(ISolution solution, TestCase testCase)
                {
                {{~ if OutputArgument.IsCollectionType ~}}
                    AssertCollectionEqualWithDetails({{ InvokeSolutionCode }}, {{ OutputArgument.TestCasePropertyCode }});
                {{~ else ~}}
                    Assert.That({{ InvokeSolutionCode }}, Is.EqualTo({{ OutputArgument.TestCasePropertyCode }}));
                {{~ end ~}}
                }

                public class TestCase : TestCaseBase
                {
                {{~ for argument in AllArguments ~}}
                    public {{ argument.Type }} {{ argument.Name }} { get; [UsedImplicitly] init; }{{ if argument.IsClassType }} = null!;{{ end }}
                {{~ end ~}}
                }
            }
            """);

        for (var i = 0; i < Examples.Length; i++)
        {
            GenerateFile($"TestCase{i + 1}.json", NoIndentArrayJsonTextWriter.Indent(Examples[i]));
        }
    }

    private static string ToPascalCase(string str) => char.ToUpper(str[0]) + str[1..];

    internal class Argument
    {
        [UsedImplicitly]
        public string Type { get; init; } = string.Empty;

        [UsedImplicitly]
        public string Name { get; set; } = string.Empty;

        [UsedImplicitly]
        public string TestCasePropertyCode { get; set; } = string.Empty;

        [UsedImplicitly]
        public bool IsClassType =>
            Type switch
            {
                "int" => false,
                "long" => false,
                "bool" => false,
                "double" => false,
                "decimal" => false,
                "char" => false,
                _ => true
            };

        [UsedImplicitly]
        public bool IsCollectionType => Type.StartsWith("IList") || Type.EndsWith("[]");

        public static Argument Create(string type, string name)
        {
            name = ToPascalCase(name);
            var testCasePropertyCode = $"testCase.{name}";

            return type switch
            {
                "ListNode" => new Argument
                {
                    Type = "int[]",
                    Name = name,
                    TestCasePropertyCode = $"ListNode.CreateOrNull({testCasePropertyCode})"
                },
                "TreeNode" => new Argument
                {
                    Type = "int?[]",
                    Name = name,
                    TestCasePropertyCode = $"TreeNode.CreateOrNull({testCasePropertyCode})"
                },
                _ => new Argument
                {
                    Type = type,
                    Name = name,
                    TestCasePropertyCode = testCasePropertyCode
                }
            };
        }
    }
}
