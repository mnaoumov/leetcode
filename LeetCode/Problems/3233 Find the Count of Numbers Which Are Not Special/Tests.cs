namespace LeetCode.Problems._3233_Find_the_Count_of_Numbers_Which_Are_Not_Special;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NonSpecialCount(testCase.L, testCase.R), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int L { get; [UsedImplicitly] init; }
        public int R { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
