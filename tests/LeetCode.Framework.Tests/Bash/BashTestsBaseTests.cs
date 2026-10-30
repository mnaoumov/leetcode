using System.Diagnostics;
using System.Text.Json;
using LeetCode.Base;
using LeetCode.Bash;
using LeetCode.Framework.Tests;
using LeetCode.Helpers;
using NUnit.Framework.Interfaces;

[assembly: ProblemDirectory("LeetCode.Framework.Tests.Bash.BashProblem", Fixtures.RelativeRoot + "/Bash")]
[assembly: ProblemDirectory("LeetCode.Framework.Tests.Bash.NoScriptsProblem", Fixtures.RelativeRoot + "/Generic")]

namespace LeetCode.Framework.Tests.Bash
{
    // Runs scripts through WSL's bash.exe, as the Bash problems do.
    [Category("Bash")]
    public class BashTestsBaseTests
    {
        [Test]
        public void Discovery_JoinsEveryScriptWithEveryTestCase()
        {
            var cases = BashTestsBase<BashProblem.Tests>.JoinedTestCases.ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(cases.Select(c => c.TestName), Is.EquivalentTo(new[] { "Solution1: TestCase1", "Solution2: TestCase1" }));
                Assert.That(cases.Single(c => c.TestName == "Solution1: TestCase1").RunState, Is.EqualTo(RunState.Runnable));
                Assert.That(cases.Single(c => c.TestName == "Solution2: TestCase1").RunState, Is.EqualTo(RunState.Explicit));
            });
        }

        [Test]
        public void Discovery_NoScriptsYieldsOneNotRunnableCase()
        {
            var cases = BashTestsBase<NoScriptsProblem.Tests>.JoinedTestCases.ToArray();

            Assert.That(cases.Select(c => (c.TestName, c.RunState)),
                Is.EqualTo(new[] { ("No Solution*.sh found", RunState.NotRunnable) }));
        }

        [Test]
        public void Discovery_NoTestCasesYieldsOneNotRunnableCase()
        {
            var cases = BashTestsBase<UnmappedProblem.Tests>.JoinedTestCases.ToArray();

            Assert.That(cases.Select(c => (c.TestName, c.RunState)),
                Is.EqualTo(new[] { ("No test cases found", RunState.NotRunnable) }));
        }

        [Test]
        public void Run_FailsOnTheWrongOutput()
        {
            var exception = Assert.Throws<MultipleAssertException>(() =>
                Run("WrongOutput.sh", new { standardOutput = "hello" }));

            Assert.That(exception.Message, Does.Contain("Standard Output").And.Contain("goodbye"));
        }

        [Test]
        public void Run_ComparesStandardError()
        {
            Run("StandardError.sh", new { standardOutput = "out", standardError = "err" });

            var exception = Assert.Throws<MultipleAssertException>(() =>
                Run("StandardError.sh", new { standardOutput = "out" }));
            Assert.That(exception.Message, Does.Contain("Standard Error"));
        }

        [Test]
        public void Run_ReadsBothStreamsPastTheirPipeBuffers()
        {
            var numbers = string.Join("\n", Enumerable.Range(1, 100_000));

            Run("LargeOutput.sh", new { standardOutput = numbers, standardError = numbers });
        }

        [Test]
        public void Run_StopsAScriptAtItsTimeout()
        {
            var stopwatch = Stopwatch.StartNew();

            var exception = Assert.Throws<AssertionException>(() =>
                Run("Sleep.sh", new { standardOutput = "", timeoutInMilliseconds = 2000 }));

            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Does.Contain("timed out after 2000 milliseconds"));
                Assert.That(stopwatch.Elapsed, Is.LessThan(TimeSpan.FromSeconds(30)));
            });
        }

        private static void Run(string scriptName, object testCase)
        {
            using var tempDir = new TempDir();
            var testCasePath = Path.Combine(tempDir.Path, "TestCase1.json");
            File.WriteAllText(testCasePath, JsonSerializer.Serialize(testCase));
            new BashProblem.Tests().Test(Fixtures.GetPath("BashCases", scriptName), testCasePath);
        }
    }
}

namespace LeetCode.Framework.Tests.Bash.BashProblem
{
    // NUnit runs this one for real: Solution1 passes, and Solution2 is skipped.
    public class Tests : BashTestsBase<Tests>;
}

namespace LeetCode.Framework.Tests.Bash.NoScriptsProblem
{
    public abstract class Tests : BashTestsBase<Tests>;
}

namespace LeetCode.Framework.Tests.Bash.UnmappedProblem
{
    public abstract class Tests : BashTestsBase<Tests>;
}
