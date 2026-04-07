using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace TemplateGenerator;

internal partial class SqlGenerator : GeneratorBase
{
    [GeneratedRegex(@"Create table If Not Exists (?<TableName>.+?) \((?<ColumnDefinitions>.+?)\)($|\r\n)")]
    private static partial Regex CreateTableRegex();

    [GeneratedRegex("'(.+?)'")]
    private static partial Regex ValuesRegex();

    [GeneratedRegex(@"^[\w_@#][\w\d_@#$]*$")]
    private static partial Regex HeaderNameRegex();

    [UsedImplicitly]
    public string SetUpScript { get; private set; } = string.Empty;

    [UsedImplicitly]
    public string TableName { get; set; } = string.Empty;

    [UsedImplicitly]
    public List<string> ColumnDefinitions { get; private set; } = [];

    [UsedImplicitly]
    public string ColumnName { get; private set; } = string.Empty;

    [UsedImplicitly]
    public string[] Values { get; private set; } = [];

    [UsedImplicitly]
    public int MaxValueLength { get; set; }

    [UsedImplicitly]
    public string TestCaseJson { get; set; } = string.Empty;

    [UsedImplicitly]
    public string[] HeaderNames { get; private set; } = [];

    public override string CommandName => "sql";
    public override string CommandDescription => "Generate SQL problem template";

    public override void Generate()
    {
        var setUpScript = ConsoleHelper.ReadMultiline("SetUp script");
        SetUpScript = FixSetUpScript(setUpScript);

        var testCases = ConsoleHelper.ReadMultiline("Test cases").Split("\r\n");
        var expectedOutputs = ConsoleHelper.ReadMultiline("Expected output").Split("\r\n");

        GenerateFile("SetUp.sql", "{{ SetUpScript }}");

        GenerateFile("Tests.cs", """
            {{ Namespace }}

            [UsedImplicitly]
            public class Tests : SelectSqlTestsBase<Tests>
            {
            }
            """);

        for (var i = 0; i < testCases.Length; i++)
        {
            var testCaseObj = JsonNode.Parse(testCases[i])?.AsObject()
                ?? throw new InvalidOperationException("Failed to parse test case JSON");
            testCaseObj["output"] = JsonNode.Parse(expectedOutputs[i]);
            var output = testCaseObj["output"] ?? throw new InvalidOperationException("Test case missing 'output' field");
            var headers = output["headers"]?.AsArray() ?? throw new InvalidOperationException("Test case output missing 'headers' field");
            HeaderNames = headers.Select(EscapeHeaderName).ToArray();
            TestCaseJson = testCaseObj.ToJsonString(new JsonSerializerOptions { WriteIndented = true });

            GenerateFile($"TestCase{i + 1}.json", "{{ TestCaseJson }}");
        }

        GenerateFile("Solution1.sql", """
            -- TODO url

            SELECT
            {{~ for headerName in HeaderNames ~}}
                {{ headerName }} = 1{{ if !for.last; ','; else; ';'; end }}
            {{~ end ~}}
            """);
    }

    private static string EscapeHeaderName(JsonNode? headerJson)
    {
        var headerName = headerJson?.GetValue<string>()
            ?? throw new InvalidOperationException($"Header name is null: {headerJson}");
        return HeaderNameRegex().IsMatch(headerName) ? headerName : $"[{headerName}]";
    }

    private string FixSetUpScript(string setUpScript) => CreateTableRegex().Replace(setUpScript, FixCreateTableStatement);

    private string FixCreateTableStatement(Match match)
    {
        TableName = match.Groups["TableName"].Value;

        var columnDefinitionsStr = match.Groups["ColumnDefinitions"].Value;
        var parts = columnDefinitionsStr.Split(", ");

        ColumnDefinitions = new List<string>();
        var complexParts = new List<string>();

        foreach (var part in parts)
        {
            if (complexParts.Count == 0)
            {
                if (!part.Contains('(') || part.Contains('(') && part.Contains(')'))
                {
                    ColumnDefinitions.Add(part);
                }
                else
                {
                    complexParts.Add(part);
                }
            }
            else if (part.EndsWith(")"))
            {
                complexParts.Add(part);
                var columnDefinition = string.Join(", ", complexParts);
                ColumnName = columnDefinition.Split(' ')[0];
                Values = ValuesRegex().Matches(columnDefinition).Select(m => m.Groups[1].Value).ToArray();
                MaxValueLength = Values.Length > 0 ? Values.Max(value => value.Length) : 0;

                columnDefinition = GenerateTemplate("""
                    {{ ColumnName}} varchar({{ MaxValueLength }}) CHECK({{ ColumnName }} IN (
                        {{- for value in Values -}}
                            '{{ value }}'{{ if !for.last; ', '; end }}
                        {{- end -}}
                    ))
                    """);

                ColumnDefinitions.Add(columnDefinition);
                complexParts.Clear();
            }
        }

        return GenerateTemplate("""
            CREATE TABLE {{ TableName }}
            (
            {{~ for columnDefinition in ColumnDefinitions ~}}
                {{ columnDefinition }}{{ if !for.last; ','; end }}
            {{~ end ~}}
            );


            """);
    }
}
