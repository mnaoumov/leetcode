namespace LeetCode.Problems._1424_Diagonal_Traverse_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindDiagonalOrder(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<int>> Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
