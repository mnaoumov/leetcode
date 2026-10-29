namespace LeetCode.Problems._3859_Count_Subarrays_With_K_Distinct_Integers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountSubarrays(testCase.Nums, testCase.K, testCase.M), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int M { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
