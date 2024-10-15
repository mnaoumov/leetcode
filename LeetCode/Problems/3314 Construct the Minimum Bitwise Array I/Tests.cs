namespace LeetCode.Problems._100451_Construct_the_Minimum_Bitwise_Array_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinBitwiseArray(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
