namespace LeetCode.Problems._2154_Keep_Multiplying_Found_Values_by_Two;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindFinalValue(testCase.Nums, testCase.Original), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Original { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
