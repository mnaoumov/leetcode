using NUnit.Framework;
using System.Text.RegularExpressions;
using Microsoft.ClearScript.V8;
using Newtonsoft.Json;

namespace LeetCode;

public class JavaScriptTestsBase<TJavaScriptTests> : TestsBase where TJavaScriptTests : JavaScriptTestsBase<TJavaScriptTests>
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("JavaScript")]
    public void Test(string solutionScriptPath, JavaScriptTestCase testCase)
    {
        using var engine = new V8ScriptEngine();
        engine.Execute(File.ReadAllText(solutionScriptPath));
        var code = $@"
let result;
try {{
    result = ({testCase.InputFunction})();
}} catch (e) {{
    result = e;
}}

JSON.stringify(result, Object.getOwnPropertyNames(result));
";
        var actualJson = (string) engine.Evaluate(code);
        var actual = JsonConvert.DeserializeObject<object>(actualJson, new PlainObjectArrayConverter());
        AssertEqualWithDetails(actual, testCase.Output);
    }

    public static IEnumerable<TestCaseData> JoinedTestCases
    {
        get
        {
            var testCases = GetTestCases<TJavaScriptTests, JavaScriptTestCase>();
            var problemTestCaseDirectory = GetProblemDirectory(typeof(TJavaScriptTests))!;
            var solutionScriptFiles = Directory.GetFiles(problemTestCaseDirectory, "Solution*.js");

            if (solutionScriptFiles.Length == 0)
            {
                Assert.Fail("No Solution*.js found");
            }

            foreach (var solutionScriptFile in solutionScriptFiles)
            {
                var solutionName = Path.GetFileNameWithoutExtension(solutionScriptFile);
                var firstLine = File.ReadLines(solutionScriptFile).First();
                var skipSolutionReason = Regex.Match(firstLine, "// SkipSolution: (.+)").Groups[1].Value;

                foreach (var testCase in testCases)
                {
                    var testCaseData = new TestCaseData(solutionScriptFile, testCase).SetName($@"{solutionName}: {testCase.TestCaseName}");

                    if (!string.IsNullOrEmpty(skipSolutionReason))
                    {
                        testCaseData.Explicit(skipSolutionReason);
                    }

                    yield return testCaseData;
                }
            }
        }
    }

}
