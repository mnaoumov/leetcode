namespace LeetCode.Problems._2927_Distribute_Candies_Among_Children_III;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DistributeCandies(testCase.N, testCase.Limit), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int Limit { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
