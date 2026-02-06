namespace LeetCode.Problems._1018_Binary_Prefix_Divisible_By_5;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.PrefixesDivBy5(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public IList<bool> Output { get; [UsedImplicitly] init; } = null!;
    }
}
