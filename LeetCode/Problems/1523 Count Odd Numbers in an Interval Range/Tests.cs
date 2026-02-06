namespace LeetCode.Problems._1523_Count_Odd_Numbers_in_an_Interval_Range;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountOdds(testCase.Low, testCase.High), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Low { get; [UsedImplicitly] init; }
        public int High { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
