namespace LeetCode.Problems._3509_Maximum_Product_of_Subsequences_With_an_Alternating_Sum_Equal_to_K;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProduct(testCase.Nums, testCase.K, testCase.Limit), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Limit { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
