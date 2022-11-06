using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2463_Minimum_Total_Distance_Traveled;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumTotalDistance(testCase.Robot, testCase.Factory), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public IList<int> Robot { get; private init; } = null!;
        public int[][] Factory { get; private init; } = null!;
        public long Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Robot = new[] { 0, 4, 6 },
                    Factory = new[]
                    {
                        new[] { 2, 2 }, new[] { 6, 2 }
                    },
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Robot = new[] { 1, -1 },
                    Factory = new[]
                    {
                        new[] { -2, 1 }, new[] { 2, 1 }
                    },
                    Output = 2,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
