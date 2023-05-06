using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace TemplateGenerator;

internal partial class JavaScriptGenerator : GeneratorBase
{
    [GeneratedRegex(@"\r\nInput:(?: |\r\n)((?:.|\r\n)+?)\r\nOutput: (.+?)(\r\n|$)")]
    private static partial Regex ExamplesRegex();

    [UsedImplicitly]
    public string SolutionTemplate { get; private set; } = null!;

    [UsedImplicitly]
    public JavaScriptExample Example { get; private set; } = null!;

    public override bool CanGenerate() => Signature == "JS";

    public override void Generate()
    {
        SolutionTemplate = ConsoleHelper.ReadMultiline("Solution template");
        var examplesStr = ConsoleHelper.ReadMultiline("Examples");

        var examples = ExamplesRegex().Matches(examplesStr).Select(match => new JavaScriptExample
        {
            InputStr = match.Groups[1].Value,
            OutputStr = match.Groups[2].Value
        }).ToArray();

        GenerateFile("Solution1.js", """
            // TODO url

            {{ SolutionTemplate }}
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
            const testFn = () => {
            };
            """);

        var testCaseCounter = 0;

        foreach (var example in examples)
        {
            testCaseCounter++;
            Example = example;

            GenerateFile($"TestCase{testCaseCounter}.js", """
            {{ Example.InputStr }}
            const output = {{ Example.OutputStr }};
            """);
        }
    }

    internal class JavaScriptExample
    {
        [UsedImplicitly]
        public string InputStr { get; init; } = null!;

        [UsedImplicitly]
        public string OutputStr { get; init; } = null!;
    }
}
