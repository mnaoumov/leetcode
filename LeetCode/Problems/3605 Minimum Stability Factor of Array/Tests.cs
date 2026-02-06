namespace LeetCode.Problems._3605_Minimum_Stability_Factor_of_Array;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinStable(testCase.Nums, testCase.MaxC), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int MaxC { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
