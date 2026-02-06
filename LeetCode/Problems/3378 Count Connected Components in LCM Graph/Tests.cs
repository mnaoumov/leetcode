namespace LeetCode.Problems._3378_Count_Connected_Components_in_LCM_Graph;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountComponents(testCase.Nums, testCase.Threshold), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Threshold { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
