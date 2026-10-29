namespace LeetCode.Problems._3835_Count_Subarrays_With_Cost_Less_Than_or_Equal_to_K;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountSubarrays(testCase.Nums, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public long K { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
