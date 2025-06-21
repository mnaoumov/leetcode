namespace LeetCode.Problems._3572_Maximize_Y_Sum_by_Picking_a_Triplet_of_Distinct_X_Values;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxSumDistinctTriplet(testCase.X, testCase.Y), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] X { get; [UsedImplicitly] init; } = null!;
        public int[] Y { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
