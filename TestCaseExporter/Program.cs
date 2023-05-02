using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestCaseExporter;

internal static partial class Program
{
    [GeneratedRegex(@"LeetCode\._(\d+)")]
    private static partial Regex NamespaceRegex();

    public static void Main()
    {
        var testCaseTypes = typeof(LeetCode.TestCaseBase).Assembly.GetTypes().Where(type => type.Name == "TestCase")
            .OrderBy(t => t.FullName)
            .ToArray();

        foreach (var testCaseType in testCaseTypes)
        {
            try
            {
                var problemNumber = NamespaceRegex().Match(testCaseType.Namespace!).Groups[1].Value;

                Console.WriteLine(problemNumber);

                var dir = Directory.GetDirectories(@"f:\dev\leetcode\LeetCode", $"{problemNumber} *")[0];

                //dynamic testCaseBuilder = Activator.CreateInstance(testCaseType)!;
                //var testCases = ((IEnumerable<object>)testCaseBuilder.TestCases).ToArray();

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
                    using var file = File.CreateText(path);
                    var serializer = new JsonSerializer
                    {
                        Formatting = Formatting.Indented,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };

                    serializer.Converters.Add(new ArrayNoIndentingConverter());

                    try
                    {
                        serializer.Serialize(file, testCase);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        file.Close();
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
        using var fileStream = File.OpenRead(testCaseFilePath);
        using var reader = new StreamReader(fileStream);
        using var jr = new JsonTextReader(reader);

        var serializer = new JsonSerializer();

        try
        {
            var testCase = serializer.Deserialize(jr, testCaseType);
            return testCase;
        }
        catch
        {
            return null;
        }
    }
}