using NUnit.Framework;
using System.Text.RegularExpressions;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;
using Newtonsoft.Json;

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

    private static V8ScriptEngine BuildEngine()
    {
        var engine = new V8ScriptEngine();
        var intervals = new V8Extended.Intervals();
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
        return engine;
    }

    private static async Task RunJavaScriptTestAsync(string solutionScriptPath, JavaScriptTestCase testCase)
    {
        var engine = Engine.Value;
        engine.Execute(await File.ReadAllTextAsync(solutionScriptPath));

        var code = $$"""
        (async () => {
            const inputFunction = {{testCase.InputFunction}};

            let result;
            try {
                result = await inputFunction();
            } catch (e) {
                result = e;
            }

            return JSON.stringify(result, Object.getOwnPropertyNames(result));
        })();
        """;

        var promise = engine.Evaluate(code);

        var actualJson = (string) (await promise.ToTask());

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
}
