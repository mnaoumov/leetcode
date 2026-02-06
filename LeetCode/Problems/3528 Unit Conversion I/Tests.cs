namespace LeetCode.Problems._3528_Unit_Conversion_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.BaseUnitConversions(testCase.Conversions), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Conversions { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
