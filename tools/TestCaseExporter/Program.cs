using System.Text.Json;
using System.Text.RegularExpressions;

namespace TestCaseExporter;

internal static partial class Program
{
    [GeneratedRegex(@"LeetCode\.Problems\._(\d+)")]
    private static partial Regex NamespaceRegex();

    private static readonly string ProblemsRoot = Path.Combine(FindRepoRoot(), "src", "LeetCode.Problems");
    /// <summary>
    /// The repo root is the nearest folder above the tool's output that holds LeetCode.slnx.
    /// </summary>
    private static string FindRepoRoot()
    {
        for (var dir = new DirectoryInfo(AppContext.BaseDirectory); dir != null; dir = dir.Parent)
        {
            if (File.Exists(Path.Combine(dir.FullName, "LeetCode.slnx")))
            {
                return dir.FullName;
            }
        }

        throw new DirectoryNotFoundException($"No LeetCode.slnx above {AppContext.BaseDirectory}");
    }

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
        var testCaseTypes = System.Reflection.Assembly.Load("LeetCode.Problems").GetTypes().Where(type => type.Name == "TestCase")
            .OrderBy(t => t.FullName)
            .ToArray();

        foreach (var testCaseType in testCaseTypes)
        {
            try
            {
                var problemNumber = NamespaceRegex().Match(testCaseType.Namespace!).Groups[1].Value;

                Console.WriteLine(problemNumber);

                var dir = Directory.GetDirectories(ProblemsRoot, $"{problemNumber} *", SearchOption.AllDirectories)[0];

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
