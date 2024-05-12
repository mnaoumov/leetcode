using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2463_Minimum_Total_Distance_Traveled;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumTotalDistance(testCase.Robot, testCase.Factory), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> Robot { get; [UsedImplicitly] init; } = null!;
        public int[][] Factory { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
