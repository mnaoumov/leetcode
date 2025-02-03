namespace LeetCode.Problems._3441_Minimum_Cost_Good_Caption;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCostGoodCaption(testCase.Caption), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Caption { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
