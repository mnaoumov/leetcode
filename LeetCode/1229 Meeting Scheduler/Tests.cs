using JetBrains.Annotations;

namespace LeetCode._1229_Meeting_Scheduler;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinAvailableDuration(testCase.Slots1, testCase.Slots2, testCase.Duration), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Slots1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Slots2 { get; [UsedImplicitly] init; } = null!;
        public int Duration { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
