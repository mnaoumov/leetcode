namespace LeetCode.Problems._0930_Binary_Subarrays_With_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumSubarraysWithSum(testCase.Nums, testCase.Goal), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Goal { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
