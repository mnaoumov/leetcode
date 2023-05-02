using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    public string SetUpScript { get; private set; } = null!;

    [UsedImplicitly]
    public string TableName { get; set; } = null!;

    [UsedImplicitly]
    public List<string> ColumnDefinitions { get; private set; } = null!;

    [UsedImplicitly]
    public string ColumnName { get; private set; } = null!;

    [UsedImplicitly]
    public string[] Values { get; private set; } = null!;

    [UsedImplicitly]
    public int MaxValueLength { get; set; }

    [UsedImplicitly]
    public string TestCaseJson { get; set; } = null!;

    [UsedImplicitly]
    public string[] HeaderNames { get; private set; } = null!;

    public override bool CanGenerate() => Signature == "SQL";

    public override void Generate()
    {
        var setUpScript = ConsoleHelper.ReadMultiline("SetUp script");
        SetUpScript = FixSetUpScript(setUpScript);

        var testCases = ConsoleHelper.ReadMultiline("Test cases").Split("\r\n");
        var expectedOutputs = ConsoleHelper.ReadMultiline("Expected output").Split("\r\n");

        GenerateFile("SetUp.sql", """
            {{ SetUpScript }}
            """);

        GenerateFile("Tests.cs", """
            using JetBrains.Annotations;

            {{ Namespace }}

            [UsedImplicitly]
            public class Tests : SelectSqlTestsBase<Tests>
            {
            }
            """);

        for (var i = 0; i < testCases.Length; i++)
        {
            var testCaseObj = JObject.Parse(testCases[i]);
            testCaseObj.Add("output", JObject.Parse(expectedOutputs[i]));
            HeaderNames = testCaseObj["output"]!["headers"]!.Select(EscapeHeaderName).ToArray();
            TestCaseJson = testCaseObj.ToString(Formatting.Indented);

            GenerateFile($"TestCase{i + 1}.json", """
                {{ TestCaseJson }}
                """);
        }

        GenerateFile("Solution1.sql", """
            -- TODO url

            SELECT
            {{~ for headerName in HeaderNames ~}}
                {{ headerName }} = 1{{ if !for.last; ','; else; ';'; end }}
            {{~ end ~}}
            """);
    }

    private static string EscapeHeaderName(JToken headerJson)
    {
        var headerName = headerJson.Value<string>()!;
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
                MaxValueLength = Values.Max(value => value.Length);

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