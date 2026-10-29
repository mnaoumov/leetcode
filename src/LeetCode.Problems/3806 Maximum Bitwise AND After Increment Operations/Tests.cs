namespace LeetCode.Problems._3806_Maximum_Bitwise_AND_After_Increment_Operations;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumAND(testCase.Nums, testCase.K, testCase.M), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int M { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
