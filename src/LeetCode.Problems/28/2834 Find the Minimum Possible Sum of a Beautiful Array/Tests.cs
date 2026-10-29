namespace LeetCode.Problems._2834_Find_the_Minimum_Possible_Sum_of_a_Beautiful_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumPossibleSum(testCase.N, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int Target { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
