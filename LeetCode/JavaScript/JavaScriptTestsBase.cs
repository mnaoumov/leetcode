using NUnit.Framework;
using System.Text.RegularExpressions;
using Microsoft.ClearScript;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;
using V8Extended;
using Path = System.IO.Path;

namespace LeetCode;

public partial class JavaScriptTestsBase<TJavaScriptTests> : TestsBase where TJavaScriptTests : JavaScriptTestsBase<TJavaScriptTests>
{
    [GeneratedRegex("// SkipSolution: (.+)")]
    private static partial Regex SkipSolutionRegex();

    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("JavaScript")]
    public void Test(string solutionScriptPath, JavaScriptTestCase testCase)
    {
        RunTestWithStackAndTimeoutChecks(testCase,
            () => RunJavaScriptTestAsync(solutionScriptPath, testCase).GetAwaiter().GetResult());
    }

    // ReSharper disable once StaticMemberInGenericType
    private static readonly Lazy<V8ScriptEngine> Engine = new(BuildEngine);
    // ReSharper disable once StaticMemberInGenericType

    private static V8ScriptEngine BuildEngine()
    {
        var engine = new V8ScriptEngine();
        var intervals = new Intervals();
        intervals.Extend(engine);
        intervals.StartEventsLoopBackground();

        engine.Execute("""
        let _fakeTime = Date.now();
        Date.now = () => _fakeTime;

        const _setTimeout = setTimeout

        setTimeout = (callback, timeout) => {
            const nextTime = _fakeTime + timeout;
            return _setTimeout(() => {
                _fakeTime = nextTime;
                callback();
            }, timeout);
        };
        """);

        engine.Execute("""
        function toJson(obj) {
            return JSON.stringify(obj, Object.getOwnPropertyNames(obj));
        }

        async function getActualResultJson() {
            try {
                return toJson(await inputFunction());
            }
            catch (e) {
                return toJson(e);
            }
        }
        """);

        return engine;
    }

    private static async Task RunJavaScriptTestAsync(string solutionScriptPath, JavaScriptTestCase testCase)
    {
        var engine = Engine.Value;
        engine.Execute(await File.ReadAllTextAsync(solutionScriptPath));
        engine.Execute($"inputFunction = {testCase.InputFunctionStr};");
        object actualResultJsonPromise = engine.Script.getActualResultJson();
        var actualResultJson = (string) await actualResultJsonPromise.ToTask();
        AssertEqualWithDetails(actualResultJson, testCase.OutputJson);
    }

    public static IEnumerable<TestCaseData> JoinedTestCases
    {
        get
        {
            var problemTestCaseDirectory = GetProblemDirectory(typeof(TJavaScriptTests))!;
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

                    if (testCase.Exception != null)
                    {
                        testCaseData.Explicit(testCase.Exception.ToString());
                    }

                    yield return testCaseData;
                }
            }
        }
    }

    private static JavaScriptTestCase GetTestCase(string testCaseScriptFile)
    {
        var testCaseName = Path.GetFileNameWithoutExtension(testCaseScriptFile);

        try
        {
            var engine = Engine.Value;
            dynamic testCaseObj = engine.Evaluate(File.ReadAllText(testCaseScriptFile));

            var timeoutInMilliseconds = testCaseObj.timeoutInMilliseconds;
            return new JavaScriptTestCase
            {
                TestCaseName = testCaseName,
                InputFunctionStr = testCaseObj.inputFunction.toString(),
                OutputJson = engine.Script.toJson(testCaseObj.output),
                TimeoutInMilliseconds = timeoutInMilliseconds is Undefined
                    ? TestCaseBase.DefaultTimeoutInMilliseconds
                    : (int) timeoutInMilliseconds
            };

        }
        catch (Exception ex)
        {
            return new JavaScriptTestCase
            {
                TestCaseName = testCaseName,
                Exception = ex
            };
        }
    }
}
