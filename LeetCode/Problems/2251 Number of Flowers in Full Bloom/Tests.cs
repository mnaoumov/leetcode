namespace LeetCode.Problems._2251_Number_of_Flowers_in_Full_Bloom;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FullBloomFlowers(testCase.Flowers, testCase.Persons), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Flowers { get; [UsedImplicitly] init; } = null!;
        public int[] Persons { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
