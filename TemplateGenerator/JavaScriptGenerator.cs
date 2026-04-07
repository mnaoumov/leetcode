using System.CommandLine;
using System.CommandLine.Parsing;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace TemplateGenerator;

internal partial class JavaScriptGenerator : GeneratorBase
{
    [GeneratedRegex(@"\r\nInput\:?(?: |\r\n)(?<Input>(?:.|\r\n)+?)\r\nOutput\:?(?: |\r\n)(?<Output>.+?)(?:\r\n|$)")]
    private static partial Regex ExamplesRegex();

    private readonly Option<string?> _descriptionOption = new("--description", "-d") { Description = "Problem description (used to extract examples)" };

    private string? _description;

    [UsedImplicitly]
    public string SolutionTemplate { get; private set; } = string.Empty;

    [UsedImplicitly]
    public string ExampleJson { get; private set; } = string.Empty;

    public override string CommandName => "js";
    public override string CommandDescription => "Generate JavaScript problem template";

    public override void ConfigureCommand(Command command)
    {
        base.ConfigureCommand(command);
        command.Add(_descriptionOption);
    }

    public override void SetOptions(ParseResult parseResult)
    {
        base.SetOptions(parseResult);
        _description = parseResult.GetValue(_descriptionOption);
    }

    public override void Generate()
    {
        SolutionTemplate = ConsoleHelper.ReadMultiline("Solution template");
        var examplesStr = _description ?? ConsoleHelper.ReadMultiline("Examples");

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
                return NoIndentArrayJsonTextWriter.Indent(JsonNode.Parse(json));
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"Warning: Failed to parse JSON, using raw text. Error: {ex.Message}");
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

        for (var i = 0; i < exampleJsons.Length; i++)
        {
            ExampleJson = exampleJsons[i];
            GenerateFile($"TestCase{i + 1}.js", $"module.exports = {exampleJsons[i]};");
        }
    }
}
