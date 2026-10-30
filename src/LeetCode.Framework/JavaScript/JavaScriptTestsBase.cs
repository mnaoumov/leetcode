using System.Diagnostics;
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
        UseNodeFor(solutionScriptPath);
        var testCase = GetTestCase(testCaseScriptPath);
        RunTestWithTimeout(testCase,
            cancellationToken => RunJavaScriptTestAsync(solutionScriptPath, testCase, testsScriptPath, cancellationToken));
    }

#pragma warning disable CA1000
    public static IEnumerable<TestCaseData> JoinedTestCases => CalculateJoinedTestCases(typeof(TJavaScriptTests));
#pragma warning restore CA1000
}

public class JavaScriptTestsBase : TestsBase
{
    private static readonly string JavaScriptDirectory = Path.Combine(AppContext.BaseDirectory, "JavaScript");
    private static readonly string TestRunnerScriptPath = Path.Combine(JavaScriptDirectory, "TestRunner.js");

    // The solution the running Node process has run. A solution can change globals (a prototype, a timer), which
    // clearing the require cache does not undo, so another solution gets a fresh process.
    private static string? _nodeSolutionScriptPath;

#pragma warning disable CA1810
    static JavaScriptTestsBase()
#pragma warning restore CA1810
    {
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

    /// <summary>
    /// Keeps the Node process for the tests of one solution, and starts a fresh one for the next solution.
    /// </summary>
    protected static void UseNodeFor(string solutionScriptPath)
    {
        if (_nodeSolutionScriptPath == solutionScriptPath)
        {
            return;
        }

        RestartNode();
        _nodeSolutionScriptPath = solutionScriptPath;

        // Under the debugger every Node process waits at its start for a debugger to attach.
        if (Debugger.IsAttached)
        {
            Process.Start("cmd.exe", ["/c", Path.Combine(JavaScriptDirectory, "Debugger.html")]);
        }
    }

    private static void RestartNode()
    {
        StaticNodeJSService.DisposeServiceProvider();
        _nodeSolutionScriptPath = null;
    }

    protected static JavaScriptTestCase GetTestCase(string testCaseScriptPath)
    {
        // The test case module says its own timeout, so Node reads it rather than a regex reading its source.
        var timeoutInMilliseconds = StaticNodeJSService.InvokeFromFileAsync<int?>(TestRunnerScriptPath,
            "getTimeoutInMilliseconds", [testCaseScriptPath]).GetAwaiter().GetResult();

        return new JavaScriptTestCase
        {
            TestCaseName = Path.GetFileNameWithoutExtension(testCaseScriptPath),
            TestCaseScriptPath = testCaseScriptPath,
            TimeoutInMilliseconds = timeoutInMilliseconds ?? JavaScriptTestCase.DefaultTimeoutInMilliseconds
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
            foreach (var testCaseData in JoinScriptTestCases(solutionScriptFile, "//", testCaseScriptFiles, argumentCount,
                         testCaseScriptFile => [solutionScriptFile, testCaseScriptFile, testsScriptPath]))
            {
                yield return testCaseData;
            }
        }
    }

    protected static async Task RunJavaScriptTestAsync(string solutionScriptPath, JavaScriptTestCase testCase, string testsScriptPath,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(testCase);

        JavaScriptTestResult result;

        try
        {
            result = (await StaticNodeJSService.InvokeFromFileAsync<JavaScriptTestResult>(TestRunnerScriptPath,
                args: [solutionScriptPath, testCase.TestCaseScriptPath, testsScriptPath, Debugger.IsAttached],
                cancellationToken: cancellationToken).ConfigureAwait(true))!;
        }
        catch
        {
            // A timed-out test leaves Node running the solution, and a failed call leaves it in no known state.
            RestartNode();
            throw;
        }

        Assert.That(result.ActualResultJson, Is.EqualTo(result.ExpectedResultJson).NoClip);
    }
}
