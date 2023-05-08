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
    public JObject Example { get; private set; } = null!;

    public override bool CanGenerate() => Signature == "JS";

    public override void Generate()
    {
        SolutionTemplate = ConsoleHelper.ReadMultiline("Solution template");
        var examplesStr = ConsoleHelper.ReadMultiline("Examples");

        var examples = ExamplesRegex().Matches(examplesStr).Select(match =>
        {
            var input = match.Groups["Input"].Value.Replace(" = ", ": ");
            var output = match.Groups["Output"].Value;
            var json = $"{{ {input}, output: {output} }}";
            return JObject.Parse(json);
        }).ToArray();

        GenerateFile("Solution1.js", """
            // TODO url

            {{ SolutionTemplate }}

            module.exports = TODO;
            """);

        GenerateFile("Tests.cs", """
            using JetBrains.Annotations;

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

        foreach (var example in examples)
        {
            testCaseCounter++;
            Example = example;

            GenerateFile($"TestCase{testCaseCounter}.js", $"module.exports = {NoIndentArrayJsonTextWriter.Indent(example)};");
        }
    }
}
