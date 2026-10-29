namespace LeetCode.Problems._3575_Maximum_Good_Subtree_Score;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GoodSubtreeSum(testCase.Vals, testCase.Par), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Vals { get; [UsedImplicitly] init; } = null!;
        public int[] Par { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
