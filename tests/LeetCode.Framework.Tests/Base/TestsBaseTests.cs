using System.Reflection;
using LeetCode.Base;
using LeetCode.Framework.Tests;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

[assembly: ProblemDirectory("LeetCode.Framework.Tests.Base.GenericProblem", Fixtures.RelativeRoot + "/Generic")]
[assembly: ProblemDirectory("LeetCode.Framework.Tests.Base.NoSolutionsProblem", Fixtures.RelativeRoot + "/Generic")]

namespace LeetCode.Framework.Tests.Base
{
    public class TestsBaseTests
    {
        [Test]
        public void SkippedSolution_IsExplicitForItsReason()
        {
            var cases = GetJoinedTestCases<GenericProblem.ISolution>();
            var skipped = cases.Where(c => c.TestName!.StartsWith("SkippedSolution:", StringComparison.Ordinal)).ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(cases, Has.Length.EqualTo(6));
                Assert.That(skipped, Has.Length.EqualTo(2));
                Assert.That(skipped.Select(c => c.RunState), Is.All.EqualTo(RunState.Explicit));
                Assert.That(skipped.Select(c => c.Properties.Get(PropertyNames.SkipReason)),
                    Is.All.EqualTo(nameof(SkipSolutionReason.NotImplemented)));
                Assert.That(cases.Except(skipped).Select(c => c.RunState), Is.All.EqualTo(RunState.Runnable));
            });
        }

        [Test]
        public void NoSolutionTypes_YieldsOneNotRunnableCaseSayingWhy()
        {
            var cases = GetJoinedTestCases<NoSolutionsProblem.ISolution>();

            Assert.That(cases, Has.Length.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(cases[0].TestName, Is.EqualTo("No Solution types found"));
                Assert.That(cases[0].RunState, Is.EqualTo(RunState.NotRunnable));
                Assert.That(cases[0].Arguments, Has.Length.EqualTo(2));
            });
        }

        [Test]
        public void Test_BuildsAFreshSolutionForEveryTest()
        {
            var tests = new GenericProblem.Tests();
            var testCaseFile = Fixtures.GetPath("Generic", "TestCase1.json");
            var seenBefore = GenericProblem.Tests.Seen.Count;

            // TestCore fails on a solution an earlier test used.
            tests.Test(typeof(GenericProblem.Solution1), testCaseFile);
            tests.Test(typeof(GenericProblem.Solution1), testCaseFile);

            Assert.That(GenericProblem.Tests.Seen, Has.Count.EqualTo(seenBefore + 2));
        }

        private static TestCaseData[] GetJoinedTestCases<TSolution>()
        {
            var property = typeof(TestsBase<TSolution, GenericProblem.ValueTestCase>).GetProperty("JoinedTestCases",
                BindingFlags.NonPublic | BindingFlags.Static)!;
            return ((IEnumerable<TestCaseData>) property.GetValue(null)!).ToArray();
        }
    }
}

namespace LeetCode.Framework.Tests.Base.GenericProblem
{
    public interface ISolution
    {
        int Calls { get; set; }
    }

    internal sealed class Solution1 : ISolution
    {
        public int Calls { get; set; }
    }

    internal sealed class Solution2 : ISolution
    {
        public int Calls { get; set; }
    }

    [SkipSolution(SkipSolutionReason.NotImplemented)]
    internal sealed class SkippedSolution : ISolution
    {
        public int Calls { get; set; }
    }

    public sealed class ValueTestCase : TestCaseBase
    {
        public int Value { get; init; }
    }

    // NUnit runs this through the real pipeline: two solutions, two test cases, the skipped solution left out.
    public class Tests : TestsBase<ISolution, ValueTestCase>
    {
        internal static readonly HashSet<ISolution> Seen = new(ReferenceEqualityComparer.Instance);

        protected override void TestCore(ISolution solution, ValueTestCase testCase)
        {
            Assert.Multiple(() =>
            {
                Assert.That(solution, Is.Not.InstanceOf<SkippedSolution>());
                Assert.That(Seen.Add(solution), Is.True, "The solution was used by an earlier test");
                Assert.That(solution.Calls++, Is.Zero);
                Assert.That(testCase.TestCaseName, Is.EqualTo($"TestCase{testCase.Value}"));
            });
        }
    }
}

namespace LeetCode.Framework.Tests.Base.NoSolutionsProblem
{
    public interface ISolution;
}
