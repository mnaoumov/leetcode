using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace TemplateGenerator;

internal partial class JavaScriptGenerator : GeneratorBase
{
    [GeneratedRegex(@"\r\nInput\:?(?: |\r\n)(?<Input>(?:.|\r\n)+?)\r\nOutput\:?(?: |\r\n)(?<Output>.+?)(?:\r\n|$)")]
    private static partial Regex ExamplesRegex();

    [UsedImplicitly]
    public string SolutionTemplate { get; private set; } = null!;

    [UsedImplicitly]
    public string ExampleJson { get; private set; } = null!;

    public override bool CanGenerate() => Signature == "JS";

    public override void Generate(string? examplesStr)
    {
        SolutionTemplate = ConsoleHelper.ReadMultiline("Solution template");
        examplesStr ??= ConsoleHelper.ReadMultiline("Examples");

        var exampleJsons = ExamplesRegex().Matches(examplesStr).Select(match =>
        {
            var input = match.Groups["Input"].Value.Replace(" = ", ": ");
            var output = match.Groups["Output"].Value;
            var json = $$"""
                {
                    {{input}},
                    output: {{output}}
                }
                """;
            try
            {
                return NoIndentArrayJsonTextWriter.Indent(JObject.Parse(json));
            }
            catch
            {
                return json;
            }
        }).ToArray();

        GenerateFile("Solution1.js", """
            // TODO url

            {{ SolutionTemplate }}

            module.exports = TODO;
            """);

        GenerateFile("Tests.cs", """
            {{ Namespace }}

            [UsedImplicitly]
            public class Tests : JavaScriptTestsBase<Tests>
            {
            }
            """);

        GenerateFile("Tests.js", """
            module.exports = async (solution, testCase) => {
                return TODO;
            };
            """);

        var testCaseCounter = 0;

        foreach (var exampleJson in exampleJsons)
        {
            testCaseCounter++;
            ExampleJson = exampleJson;

            GenerateFile($"TestCase{testCaseCounter}.js", $"module.exports = {exampleJson};");
        }
    }
}
