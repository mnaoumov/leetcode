using NUnit.Framework;
using System.Text.RegularExpressions;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;
using Path = System.IO.Path;
using Microsoft.ClearScript;

namespace LeetCode;

public partial class JavaScriptTestsBase<TJavaScriptTests> : TestsBase where TJavaScriptTests : JavaScriptTestsBase<TJavaScriptTests>
{
    [GeneratedRegex("// SkipSolution: (.+)")]
    private static partial Regex SkipSolutionRegex();

    [GeneratedRegex("const timeoutInMilliseconds = (\\d+);")]
    private static partial Regex TimeoutInMillisecondsRegex();

    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("JavaScript")]
    public void Test(string solutionScriptPath, JavaScriptTestCase testCase)
    {
        RunTestWithStackAndTimeoutChecks(testCase,
            () => RunJavaScriptTestAsync(solutionScriptPath, testCase).GetAwaiter().GetResult());
    }

    private static V8ScriptEngine BuildEngine()
    {
        var engine = new V8ScriptEngine();

        void SetTimeout(ScriptObject callback, int timeout)
        {
            var timer = new Timer(_ => callback.Invoke(asConstructor: false));
            timer.Change(timeout, Timeout.Infinite);
        }

        engine.Script._setTimeout = (Action<ScriptObject, int>) SetTimeout;

        engine.Execute("""
        let _fakeTime = Date.now();
        Date.now = () => _fakeTime;

        var setTimeout = (callback, timeout) => {
            const nextTime = _fakeTime + timeout;
            _setTimeout(() => {
                _fakeTime = nextTime;
                callback();
            }, timeout);
        };
        """);

        engine.Execute("""
        var toJson = (obj) => {
            if (obj === undefined) {
                return "undefined";
            }

            const propertyNames = obj === null ? [] : Object.getOwnPropertyNames(obj);
            return JSON.stringify(obj, propertyNames);
        }

        var getActualResultJson = async () => {
            try {
                return toJson(await testFn());
            }
            catch (e) {
                return toJson(e);
            }
        };

        var getOutputJson = () => toJson(output);
        """);

        return engine;
    }

    private static async Task RunJavaScriptTestAsync(string solutionScriptPath, JavaScriptTestCase testCase)
    {
        var problemTestCaseDirectory = GetProblemDirectory(typeof(TJavaScriptTests));
        using var engine = BuildEngine();
        engine.Execute(await File.ReadAllTextAsync(solutionScriptPath));
        engine.Execute(await File.ReadAllTextAsync(testCase.TestCaseScriptPath));
        engine.Execute(await File.ReadAllTextAsync($@"{problemTestCaseDirectory}\Tests.js"));
        object actualResultJsonPromise = engine.Script.getActualResultJson();
        var actualResultJson = (string) await actualResultJsonPromise.ToTask();
        var outputJson = (string) engine.Script.getOutputJson();
        AssertEqualWithDetails(actualResultJson, outputJson);
    }

    public static IEnumerable<TestCaseData> JoinedTestCases
    {
        get
        {
            var problemTestCaseDirectory = GetProblemDirectory(typeof(TJavaScriptTests))!;
            var testsFile = $@"{problemTestCaseDirectory}\Tests.js";

            if (!File.Exists(testsFile))
            {
                Assert.Fail("No Tests.js found");
            }

            var solutionScriptFiles = Directory.GetFiles(problemTestCaseDirectory, "Solution*.js");
            var testCaseScriptFiles = Directory.GetFiles(problemTestCaseDirectory, "TestCase*.js");
            var testCases = testCaseScriptFiles.Select(GetTestCase).ToArray();

            if (solutionScriptFiles.Length == 0)
            {
                Assert.Fail("No Solution*.js found");
            }

            if (testCases.Length == 0)
            {
                Assert.Fail("No TestCase*.js found");
            }

            foreach (var solutionScriptFile in solutionScriptFiles)
            {
                var solutionName = Path.GetFileNameWithoutExtension(solutionScriptFile);
                var firstLine = File.ReadLines(solutionScriptFile).First();
                var skipSolutionReason = SkipSolutionRegex().Match(firstLine).Groups[1].Value;

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

    private static JavaScriptTestCase GetTestCase(string testCaseScriptPath)
    {
        var testCaseName = Path.GetFileNameWithoutExtension(testCaseScriptPath);

        var content = File.ReadAllText(testCaseScriptPath);
        var timeoutInMillisecondsStr = TimeoutInMillisecondsRegex().Match(content).Groups[1].Value;
        var timeoutInMilliseconds = int.TryParse(timeoutInMillisecondsStr, out var value)
            ? value
            : TestCaseBase.DefaultTimeoutInMilliseconds;
        return new JavaScriptTestCase
        {
            TestCaseName = testCaseName,
            TestCaseScriptPath = testCaseScriptPath,
            TimeoutInMilliseconds = timeoutInMilliseconds
        };
    }
}
