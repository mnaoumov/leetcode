using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1272_Remove_Interval;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RemoveInterval(testCase.Intervals, testCase.ToBeRemoved), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Intervals { get; [UsedImplicitly] init; } = null!;
        public int[] ToBeRemoved { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
