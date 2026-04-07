using System.Text.Json;
using System.Text.RegularExpressions;

namespace TestCaseExporter;

internal static partial class Program
{
    [GeneratedRegex(@"LeetCode\._(\d+)")]
    private static partial Regex NamespaceRegex();

    private static readonly JsonSerializerOptions SerializeOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new ArrayNoIndentingConverter() }
    };

    private static readonly JsonSerializerOptions DeserializeOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static void Main()
    {
        var testCaseTypes = typeof(LeetCode.Base.TestCaseBase).Assembly.GetTypes().Where(type => type.Name == "TestCase")
            .OrderBy(t => t.FullName)
            .ToArray();

        foreach (var testCaseType in testCaseTypes)
        {
            try
            {
                var problemNumber = NamespaceRegex().Match(testCaseType.Namespace!).Groups[1].Value;

                Console.WriteLine(problemNumber);

                var dir = Directory.GetDirectories(@"f:\dev\leetcode\LeetCode", $"{problemNumber} *")[0];

                var testCaseFiles = Directory.GetFiles(dir, "TestCase*.json").OrderBy(x => x);
                var testCases = testCaseFiles.Select(file => FromJson(file, testCaseType)).ToArray();

                var index = 1;

                foreach (var testCase in testCases)
                {
                    if (testCase == null)
                    {
                        index++;
                        continue;
                    }

                    var path = $@"{dir}\TestCase{index}.json";

                    try
                    {
                        var json = JsonSerializer.Serialize(testCase, testCaseType, SerializeOptions);
                        File.WriteAllText(path, json);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        File.WriteAllText(path, "{ \"TODO\": true }");
                    }

                    index++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    private static object? FromJson(string testCaseFilePath, Type testCaseType)
    {
        try
        {
            using var fileStream = File.OpenRead(testCaseFilePath);
            return JsonSerializer.Deserialize(fileStream, testCaseType, DeserializeOptions);
        }
        catch
        {
            return null;
        }
    }
}
