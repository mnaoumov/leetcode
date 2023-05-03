using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace TemplateGenerator;

internal partial class JavaScriptGenerator : GeneratorBase
{
    [GeneratedRegex(@"\r\nInput: (.+?)\r\nOutput: (.+?)(\r\n|$)")]
    private static partial Regex ExamplesRegex();

    [UsedImplicitly]
    public string TestCaseJson { get; set; } = null!;

    [UsedImplicitly]
    public string[] HeaderNames { get; private set; } = null!;

    [UsedImplicitly]
    public JavaScriptExample Example { get; private set; } = null!;
    
    public override bool CanGenerate() => Signature == "JS";

    public override void Generate()
    {
        var solutionTemplate = ConsoleHelper.ReadMultiline("Solution template");
        var examplesStr = ConsoleHelper.ReadMultiline("Examples");

        var examples = ExamplesRegex().Matches(examplesStr).Select(match => new JavaScriptExample
        {
            InputFunctionStr = match.Groups[1].Value,
            OutputStr = match.Groups[2].Value
        }).ToArray();

        GenerateFile("Solution1.js", solutionTemplate);

        GenerateFile("Tests.cs", """
            using JetBrains.Annotations;

            {{ Namespace }}

            [UsedImplicitly]
            public class Tests : JavaScriptTestsBase<Tests>
            {
            }
            """);

        var testCaseCounter = 0;

        foreach (var example in examples)
        {
            testCaseCounter++;
            Example = example;

            GenerateFile($"TestCase{testCaseCounter}.json", """
            {
                "inputFunction": "{{ Example.InputFunctionStr }}",
                "output": {{ Example.OutputStr }}
            }
            """);
        }
    }

    internal class JavaScriptExample
    {
        [UsedImplicitly]
        public string InputFunctionStr { get; init; } = null!;

        [UsedImplicitly]
        public string OutputStr { get; init; } = null!;
    }
}
