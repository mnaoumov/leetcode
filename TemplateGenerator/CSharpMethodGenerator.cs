using System.CommandLine;
using System.CommandLine.Parsing;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace TemplateGenerator;

internal partial class CSharpMethodGenerator : GeneratorBase
{
    [GeneratedRegex(@"^(?<OutputType>\S+) (?<MethodName>\S+?)\s*\((?<Arguments>.+)?\)$")]
    private static partial Regex SignatureRegex();

    [GeneratedRegex(@"\r\nInput: (?<Input>(.|\r\n)+?)\r\nOutput: (?<Output>.+?)($|\r\n)")]
    private static partial Regex ExamplesRegex();

    private readonly Option<string> _signatureOption = new("--method-signature") { Description = "Method signature (e.g. 'int[] twoSum(int[] nums, int target)')", Required = true };
    private readonly Option<string?> _descriptionOption = new("--description") { Description = "Problem description (used to extract examples)" };

    private string _signature = string.Empty;
    private string? _description;

    [UsedImplicitly]
    public string Signature => _signature;

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

    public override string CommandName => "csharp-method";
    public override string CommandDescription => "Generate C# method problem template";

    public override void ConfigureCommand(Command command)
    {
        base.ConfigureCommand(command);
        command.Add(_signatureOption);
        command.Add(_descriptionOption);
    }

    public override void SetOptions(ParseResult parseResult)
    {
        base.SetOptions(parseResult);
        _signature = (parseResult.GetValue(_signatureOption)
            ?? throw new InvalidOperationException("Signature is required"))
            .Replace("public ", "");
        _description = parseResult.GetValue(_descriptionOption);
    }

    public override void Generate()
    {
        var signatureMatch = SignatureRegex().Match(_signature);
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

        var examplesStr = _description ?? ConsoleHelper.ReadMultiline("Examples");
        Examples = ExamplesRegex().Matches(examplesStr).Select(match =>
        {
            var input = match.Groups["Input"].Value.Replace(" = ", ": ");
            var output = match.Groups["Output"].Value;
            var json = $"{{ {input}, output: {output} }}";
            var obj = (JsonObject)JsonNode.Parse(json)!;

            var ordered = new JsonObject { ["$schema"] = "../../Base/testcase.schema.json" };

            foreach (var (key, value) in obj)
            {
                ordered[key] = value?.DeepClone();
            }

            return ordered;
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
