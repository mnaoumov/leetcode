namespace LeetCode.Problems._3757_Number_of_Effective_Subsequences;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountEffective(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
