using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestCaseExporter;

var testCaseTypes = typeof(LeetCode.TestCaseBase<>).Assembly.GetTypes().Where(type => type.Name == "TestCase")
    .OrderBy(t => t.FullName)
    .ToArray();

foreach (var testCaseType in testCaseTypes)
{
    try
    {
        var problemNumber = Regex.Match(testCaseType.Namespace!, @"LeetCode\._(\d+)").Groups[1].Value;

        Console.WriteLine(problemNumber);

        var dir = Directory.GetDirectories(@"f:\dev\leetcode\LeetCode", $"{problemNumber} *")[0];

        dynamic testCaseBuilder = Activator.CreateInstance(testCaseType)!;
        var testCases = ((IEnumerable<object>)testCaseBuilder.TestCases).ToArray();

        var index = 1;

        foreach (var testCase in testCases)
        {
            var path = $@"{dir}\TestCase{index}.json";
            using var file = File.CreateText(path);
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore,
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