using System.Reflection;
using LeetCode.Base;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

[assembly: ProblemDirectory("LeetCode.Framework.Tests.Base.JoinedProblem", "07/0712 Minimum ASCII Delete Sum for Two Strings")]

namespace LeetCode.Framework.Tests.Base
{
    public class JoinedTestCasesTests
    {
        // Discovery must hold no solution instance and no parsed test case: a shared instance leaks state between test
        // cases, and parsing every case up front holds every input of every problem for the whole run.
        [Test]
        public void MappedProblem_YieldsSolutionTypesAndTestCasePaths()
        {
            var cases = GetJoinedTestCases<JoinedProblem.ISolution>();

            Assert.That(cases.Select(c => c.TestName), Is.EquivalentTo(new[]
            {
                "Solution1: TestCase1", "Solution1: TestCase2", "Solution2: TestCase1", "Solution2: TestCase2"
            }));

            foreach (var testCaseData in cases)
            {
                Assert.That(testCaseData.Arguments, Has.Length.EqualTo(2));
                Assert.That(testCaseData.Arguments[0], Is.InstanceOf<Type>());
                Assert.That(testCaseData.Arguments[1], Is.TypeOf<string>().And.EndsWith(".json"));
                Assert.That(testCaseData.RunState, Is.EqualTo(RunState.Runnable));
            }
        }

        [Test]
        public void UnmappedProblem_YieldsOneNotRunnableCaseSayingWhy()
        {
            var cases = GetJoinedTestCases<UnmappedProblem.ISolution>();

            Assert.That(cases, Has.Length.EqualTo(1));
            Assert.That(cases[0].TestName, Is.EqualTo("No test cases found"));
            Assert.That(cases[0].RunState, Is.EqualTo(RunState.NotRunnable));
            Assert.That(cases[0].Properties.Get(PropertyNames.SkipReason), Is.EqualTo("No test cases found"));
            Assert.That(cases[0].Arguments, Has.Length.EqualTo(2));
        }

        private static TestCaseData[] GetJoinedTestCases<TSolution>()
        {
            var property = typeof(TestsBase<TSolution, FakeTestCase>).GetProperty("JoinedTestCases",
                BindingFlags.NonPublic | BindingFlags.Static)!;
            return ((IEnumerable<TestCaseData>) property.GetValue(null)!).ToArray();
        }

        public sealed class FakeTestCase : TestCaseBase;
    }
}

namespace LeetCode.Framework.Tests.Base.JoinedProblem
{
    public interface ISolution;

    internal sealed class Solution1 : ISolution;

    internal sealed class Solution2 : ISolution;
}

namespace LeetCode.Framework.Tests.Base.UnmappedProblem
{
    public interface ISolution;

    internal sealed class Solution1 : ISolution;
}
