using System.Diagnostics;
using System.Text.RegularExpressions;
using Jering.Javascript.NodeJS;
using Path = System.IO.Path;

namespace LeetCode.JavaScript;

public abstract class JavaScriptTestsBase<TJavaScriptTests> : JavaScriptTestsBase where TJavaScriptTests : JavaScriptTestsBase<TJavaScriptTests>
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("JavaScript")]
    public void Test(string solutionScriptPath, string testCaseScriptPath, string testsScriptPath)
    {
        var testCase = GetTestCase(testCaseScriptPath);
        RunTestWithTimeout(testCase,
            cancellationToken => RunJavaScriptTestAsync(solutionScriptPath, testCase, testsScriptPath, cancellationToken));
    }

#pragma warning disable CA1000
    public static IEnumerable<TestCaseData> JoinedTestCases => CalculateJoinedTestCases(typeof(TJavaScriptTests));
#pragma warning restore CA1000
}

public partial class JavaScriptTestsBase : TestsBase
{
    [GeneratedRegex("// SkipSolution: (.+)")]
    private static partial Regex SkipSolutionRegex();

    [GeneratedRegex(@"timeoutInMilliseconds: (\d+);")]
    private static partial Regex TimeoutInMillisecondsRegex();

    private static readonly string TestRunnerScriptPath;

#pragma warning disable CA1810
    static JavaScriptTestsBase()
#pragma warning restore CA1810
    {
        var dir = Directory.GetCurrentDirectory();
        TestRunnerScriptPath = Path.Combine(dir, "JavaScript", "TestRunner.js");

        if (!File.Exists(TestRunnerScriptPath))
        {
            Console.Error.WriteLine("TestRunner.js is missing");
            return;
        }

        if (!Debugger.IsAttached)
        {
            return;
        }

        StaticNodeJSService.Configure<NodeJSProcessOptions>(options => options.NodeAndV8Options = "--inspect-brk");
        StaticNodeJSService.Configure<OutOfProcessNodeJSServiceOptions>(options =>
        {
            var fiveMinutesInMilliseconds = (int) TimeSpan.FromMinutes(5).TotalMilliseconds;
            options.ConnectionTimeoutMS = fiveMinutesInMilliseconds;
            options.InvocationTimeoutMS = fiveMinutesInMilliseconds;
        });
    }

    protected static JavaScriptTestCase GetTestCase(string testCaseScriptPath)
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

    protected static IEnumerable<TestCaseData> CalculateJoinedTestCases(Type problemRelatedType)
    {
        const int argumentCount = 3;
        var testsScriptPath = GetProblemFiles(problemRelatedType, "Tests.js").SingleOrDefault();

        if (testsScriptPath == null)
        {
            yield return DiscoveryFailure("No Tests.js found", argumentCount);
            yield break;
        }

        var solutionScriptFiles = GetProblemFiles(problemRelatedType, "Solution*.js");

        if (solutionScriptFiles.Length == 0)
        {
            yield return DiscoveryFailure("No Solution*.js found", argumentCount);
            yield break;
        }

        var testCaseScriptFiles = GetProblemFiles(problemRelatedType, "TestCase*.js");

        if (testCaseScriptFiles.Length == 0)
        {
            yield return DiscoveryFailure("No TestCase*.js found", argumentCount);
            yield break;
        }

        foreach (var solutionScriptFile in solutionScriptFiles)
        {
            var solutionName = Path.GetFileNameWithoutExtension(solutionScriptFile);
            var skipSolutionReason = SkipSolutionRegex().Match(ReadFirstLine(solutionScriptFile)).Groups[1].Value;

            foreach (var testCaseScriptFile in testCaseScriptFiles)
            {
                var testCaseData =
                    new TestCaseData(solutionScriptFile, testCaseScriptFile, testsScriptPath)
                        .SetName($"{solutionName}: {Path.GetFileNameWithoutExtension(testCaseScriptFile)}");

                if (!string.IsNullOrEmpty(skipSolutionReason))
                {
                    testCaseData.Explicit(skipSolutionReason);
                }

                yield return testCaseData;
            }
        }
    }

    protected static async Task RunJavaScriptTestAsync(string solutionScriptPath, JavaScriptTestCase testCase, string testsScriptPath,
        CancellationToken cancellationToken)
    {
        if (Debugger.IsAttached)
        {
            Process.Start("cmd.exe", new[] { "/c", Path.Combine(Directory.GetCurrentDirectory(), "JavaScript", "Debugger.html") });
        }

        try
        {
            var result = (await StaticNodeJSService.InvokeFromFileAsync<JavaScriptTestResult>(TestRunnerScriptPath,
                args: new object?[]
                {
                    solutionScriptPath, testCase.TestCaseScriptPath, testsScriptPath, Debugger.IsAttached
                }, cancellationToken: cancellationToken).ConfigureAwait(true))!;

            Assert.That(result.ActualResultJson, Is.EqualTo(result.ExpectedResultJson).NoClip);
        }
        finally
        {
            StaticNodeJSService.DisposeServiceProvider();
        }
    }
}
