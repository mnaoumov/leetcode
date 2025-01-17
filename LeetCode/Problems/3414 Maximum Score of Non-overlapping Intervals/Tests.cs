namespace LeetCode.Problems._3414_Maximum_Score_of_Non_overlapping_Intervals;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MaximumWeight(testCase.Intervals), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<int>> Intervals { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
