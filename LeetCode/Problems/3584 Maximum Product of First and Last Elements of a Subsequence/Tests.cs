namespace LeetCode.Problems._3584_Maximum_Product_of_First_and_Last_Elements_of_a_Subsequence;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumProduct(testCase.Nums, testCase.M), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int M { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
