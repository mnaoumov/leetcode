namespace LeetCode.Problems._2563_Count_the_Number_of_Fair_Pairs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountFairPairs(testCase.Nums, testCase.Lower, testCase.Upper), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Lower { get; [UsedImplicitly] init; }
        public int Upper { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
