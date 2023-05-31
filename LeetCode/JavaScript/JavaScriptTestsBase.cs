using System.Diagnostics;
using NUnit.Framework;
using System.Text.RegularExpressions;
using Jering.Javascript.NodeJS;
using Path = System.IO.Path;

namespace LeetCode;

public abstract class JavaScriptTestsBase<TJavaScriptTests> : JavaScriptTestsBase where TJavaScriptTests : JavaScriptTestsBase<TJavaScriptTests>
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("JavaScript")]
    public void Test(string solutionScriptPath, JavaScriptTestCase testCase, string testsScriptPath)
    {
        RunTestWithStackAndTimeoutChecks(testCase,
            () => RunJavaScriptTestAsync(solutionScriptPath, testCase, testsScriptPath).GetAwaiter().GetResult());
    }

    public static IEnumerable<TestCaseData> JoinedTestCases => GetJoinedTestCases(typeof(TJavaScriptTests));
}

public partial class JavaScriptTestsBase : TestsBase
{
    [GeneratedRegex("// SkipSolution: (.+)")]
    private static partial Regex SkipSolutionRegex();

    [GeneratedRegex(@"timeoutInMilliseconds: (\d+);")]
    private static partial Regex TimeoutInMillisecondsRegex();

    private static readonly string TestRunnerScriptPath;

    static JavaScriptTestsBase()
    {
        var dir = Directory.GetCurrentDirectory();
        TestRunnerScriptPath = $@"{dir}\JavaScript\TestRunner.js";

        if (!File.Exists(TestRunnerScriptPath))
        {
            throw new InvalidOperationException("TestRunner.js is missing");
        }

        if (!Debugger.IsAttached)
        {
            return;
        }

        StaticNodeJSService.Configure<NodeJSProcessOptions>(options => options.NodeAndV8Options = "--inspect-brk");
        StaticNodeJSService.Configure<OutOfProcessNodeJSServiceOptions>(options => options.TimeoutMS = -1);
    }

    private static JavaScriptTestCase GetTestCase(string testCaseScriptPath)
    {
        var testCaseName = Path.GetFileNameWithoutExtension(testCaseScriptPath);

        var content = File.ReadAllText(testCaseScriptPath);
        var timeoutInMillisecondsStr = TimeoutInMillisecondsRegex().Match(content).Groups[1].Value;
        var timeoutInMilliseconds = int.TryParse(timeoutInMillisecondsStr, out var value)
            ? value
            : JavaScriptTestCase.DefaultTimeoutInMilliseconds;
        return new JavaScriptTestCase
        {
            TestCaseName = testCaseName,
            TestCaseScriptPath = testCaseScriptPath,
            TimeoutInMilliseconds = timeoutInMilliseconds
        };
    }

    protected static IEnumerable<TestCaseData> GetJoinedTestCases(Type problemRelatedType)
    {
        var problemTestCaseDirectory = GetProblemDirectory(problemRelatedType)!;
        var testsScriptPath = $@"{problemTestCaseDirectory}\Tests.js";

        if (!File.Exists(testsScriptPath))
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
                var testCaseData =
                    new TestCaseData(solutionScriptFile, testCase, testsScriptPath).SetName($@"{solutionName}: {testCase.TestCaseName}");

                if (!string.IsNullOrEmpty(skipSolutionReason))
                {
                    testCaseData.Explicit(skipSolutionReason);
                }

                yield return testCaseData;
            }
        }
    }

    protected static async Task RunJavaScriptTestAsync(string solutionScriptPath, JavaScriptTestCase testCase, string testsScriptPath)
    {
        if (Debugger.IsAttached)
        {
            Process.Start("cmd.exe", new[] { "/c", $@"{Directory.GetCurrentDirectory()}\JavaScript\Debugger.html" });
        }

        try
        {
            var result = (await StaticNodeJSService.InvokeFromFileAsync<JavaScriptTestResult>(TestRunnerScriptPath,
                args: new object?[]
                {
                    solutionScriptPath, testCase.TestCaseScriptPath, testsScriptPath, Debugger.IsAttached
                }))!;

            Assert.That(result.ActualResultJson, Is.EqualTo(result.ExpectedResultJson).NoClip);
        }
        finally
        {
            StaticNodeJSService.DisposeServiceProvider();
        }
    }
}
