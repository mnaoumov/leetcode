using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace TemplateGenerator;

internal partial class CSharpGenerator : GeneratorBase
{
    [GeneratedRegex(@"^public (?<OutputType>\S+) (?<MethodName>\S+?)\s*\((?<Arguments>.+)?\)$")]
    private static partial Regex SignatureRegex();

    [GeneratedRegex(@"\r\nInput: (?<Input>(.|\r\n)+?)\r\nOutput: (?<Output>.+?)($|\r\n)")]
    private static partial Regex ExamplesRegex();

    [UsedImplicitly]
    public JObject[] Examples { get; set; } = null!;

    [UsedImplicitly]
    public string MethodName { get; private set; } = null!;

    [UsedImplicitly]
    public Argument[] InputArguments { get; private set; } = Array.Empty<Argument>();

    [UsedImplicitly]
    public Argument OutputArgument { get; private set; } = null!;

    [UsedImplicitly]
    public string InvokeSolutionCode { get; private set; } = null!;

    [UsedImplicitly]
    public IEnumerable<Argument> AllArguments => InputArguments.Append(OutputArgument);

    public override bool CanGenerate() => SignatureRegex().IsMatch(Signature);

    public override void Generate()
    {
        var signatureMatch = SignatureRegex().Match(Signature);
        var outputType = signatureMatch.Groups["OutputType"].Value;
        MethodName = signatureMatch.Groups["MethodName"].Value;
        InputArguments = signatureMatch.Groups["Arguments"].Value.Split(", ").Select(argumentStr =>
        {
            var parts = argumentStr.Split(' ');
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

        var examplesStr = ConsoleHelper.ReadMultiline("Examples");
        Examples = ExamplesRegex().Matches(examplesStr).Select(match =>
        {
            var input = match.Groups["Input"].Value.Replace(" = ", ": ");
            var output = match.Groups["Output"].Value;
            var json = $"{{ {input}, output: {output} }}";
            return JObject.Parse(json);
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
                {{ Signature }}
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
                protected override void TestImpl(ISolution solution, TestCase testCase)
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

        var testCaseCounter = 0;

        foreach (var example in Examples)
        {
            testCaseCounter++;
            GenerateFile($"TestCase{testCaseCounter}.json", NoIndentArrayJsonTextWriter.Indent(example));
        }
    }

    private static string ToPascalCase(string str) => char.ToUpper(str[0]) + str[1..];

    internal class Argument
    {
        [UsedImplicitly]
        public string Type { get; init; } = null!;

        [UsedImplicitly]
        public string Name { get; set; } = null!;

        [UsedImplicitly]
        public string TestCasePropertyCode { get; set; } = null!;

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
