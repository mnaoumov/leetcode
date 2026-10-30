using System.Diagnostics;
using LeetCode.Base;
using LeetCode.Framework.Tests;
using LeetCode.JavaScript;
using NUnit.Framework.Interfaces;

[assembly: ProblemDirectory("LeetCode.Framework.Tests.JavaScript.JavaScriptProblem", Fixtures.RelativeRoot + "/JavaScript")]
[assembly: ProblemDirectory("LeetCode.Framework.Tests.JavaScript.NoTestsScriptProblem", Fixtures.RelativeRoot + "/Generic")]
[assembly: ProblemDirectory("LeetCode.Framework.Tests.JavaScript.NoSolutionsProblem", Fixtures.RelativeRoot + "/JavaScriptNoSolutions")]
[assembly: ProblemDirectory("LeetCode.Framework.Tests.JavaScript.NoTestCasesProblem", Fixtures.RelativeRoot + "/JavaScriptNoTestCases")]

namespace LeetCode.Framework.Tests.JavaScript
{
    [Category("JavaScript")]
    public class JavaScriptTestsBaseTests
    {
        private static readonly string TestsScript = Fixtures.GetPath("JavaScript", "Tests.js");
        private static readonly string TestCase1 = Fixtures.GetPath("JavaScript", "TestCase1.js");

        [Test]
        public void Discovery_JoinsEveryScriptWithEveryTestCase()
        {
            var cases = JavaScriptTestsBase<JavaScriptProblem.Tests>.JoinedTestCases.ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(cases.Select(c => c.TestName), Is.EquivalentTo(new[]
                {
                    "Solution1: TestCase1", "Solution1: TestCase2", "Solution2: TestCase1", "Solution2: TestCase2"
                }));
                Assert.That(cases.Where(c => c.TestName!.StartsWith("Solution1", StringComparison.Ordinal)).Select(c => c.RunState),
                    Is.All.EqualTo(RunState.Runnable));
                Assert.That(cases.Where(c => c.TestName!.StartsWith("Solution2", StringComparison.Ordinal)).Select(c => c.RunState),
                    Is.All.EqualTo(RunState.Explicit));
                Assert.That(cases.Select(c => c.Arguments[2]), Is.All.EqualTo(TestsScript));
            });
        }

        [Test]
        public void Discovery_NoTestsScriptYieldsOneNotRunnableCase() =>
            AssertDiscoveryFailure(JavaScriptTestsBase<NoTestsScriptProblem.Tests>.JoinedTestCases, "No Tests.js found");

        [Test]
        public void Discovery_NoSolutionsYieldsOneNotRunnableCase() =>
            AssertDiscoveryFailure(JavaScriptTestsBase<NoSolutionsProblem.Tests>.JoinedTestCases, "No Solution*.js found");

        [Test]
        public void Discovery_NoTestCasesYieldsOneNotRunnableCase() =>
            AssertDiscoveryFailure(JavaScriptTestsBase<NoTestCasesProblem.Tests>.JoinedTestCases, "No TestCase*.js found");

        private static void AssertDiscoveryFailure(IEnumerable<TestCaseData> joinedTestCases, string message)
        {
            var cases = joinedTestCases.ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(cases.Select(c => (c.TestName, c.RunState)), Is.EqualTo(new[] { (message, RunState.NotRunnable) }));
                Assert.That(cases[0].Arguments, Has.Length.EqualTo(3));
            });
        }

        [Test]
        public void TestCase_ReadsItsOwnTimeoutOrTheDefault()
        {
            Assert.Multiple(() =>
            {
                Assert.That(JavaScriptProblem.Tests.ReadTestCase(TestCase1).TimeoutInMilliseconds,
                    Is.EqualTo(JavaScriptTestCase.DefaultTimeoutInMilliseconds));
                Assert.That(JavaScriptProblem.Tests.ReadTestCase(Fixtures.GetPath("JavaScript", "TestCase2.js")).TimeoutInMilliseconds,
                    Is.EqualTo(3000));
                Assert.That(JavaScriptProblem.Tests.ReadTestCase(TestCase1).TestCaseName, Is.EqualTo("TestCase1"));
            });
        }

        [Test]
        public void Run_PassesTheRightAnswer() => Run(Fixtures.GetPath("JavaScript", "Solution1.js"), TestCase1);

        [Test]
        public void Run_FailsTheWrongAnswer()
        {
            var exception = Assert.Throws<AssertionException>(() => Run(Case("WrongAnswer.js"), TestCase1));

            Assert.That(exception.Message, Does.Contain("4").And.Contain("3"));
        }

        [Test]
        public void Run_FailsAThrowingSolutionWithItsError()
        {
            var exception = Assert.Throws<AssertionException>(() => Run(Case("Throws.js"), TestCase1));

            Assert.That(exception.Message, Does.Contain("boom"));
        }

        [Test]
        public void Run_RunsTimersOnAFakeClock()
        {
            var stopwatch = Stopwatch.StartNew();

            Run(Case("Timer.js"), TestCase1);

            Assert.That(stopwatch.Elapsed, Is.LessThan(TimeSpan.FromSeconds(30)));
        }

        // A solution stuck in a loop holds the Node process, so the runner replaces it for the next test.
        [Test]
        public void Run_TimesOutALoopingSolutionAndRecovers()
        {
            var exception = Assert.Throws<AssertionException>(() =>
                Run(Case("Loop.js"), Case("TestCaseShortTimeout.js")));

            Assert.That(exception.Message, Does.Contain("timed out after 500 milliseconds"));

            Run(Fixtures.GetPath("JavaScript", "Solution1.js"), TestCase1);
        }

        private static string Case(string fileName) => Fixtures.GetPath("JavaScriptCases", fileName);

        private static void Run(string solutionScript, string testCaseScript) =>
            new JavaScriptProblem.Tests().Test(solutionScript, testCaseScript, TestsScript);
    }
}

namespace LeetCode.Framework.Tests.JavaScript.JavaScriptProblem
{
    // NUnit runs this one for real: Solution1 passes both test cases, and Solution2 is skipped.
    public class Tests : JavaScriptTestsBase<Tests>
    {
        internal static JavaScriptTestCase ReadTestCase(string testCaseScriptPath) => GetTestCase(testCaseScriptPath);
    }
}

namespace LeetCode.Framework.Tests.JavaScript.NoTestsScriptProblem
{
    public abstract class Tests : JavaScriptTestsBase<Tests>;
}

namespace LeetCode.Framework.Tests.JavaScript.NoSolutionsProblem
{
    public abstract class Tests : JavaScriptTestsBase<Tests>;
}

namespace LeetCode.Framework.Tests.JavaScript.NoTestCasesProblem
{
    public abstract class Tests : JavaScriptTestsBase<Tests>;
}
