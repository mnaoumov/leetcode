namespace LeetCode.Problems._2466_Count_Ways_To_Build_Good_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountGoodStrings(testCase.Low, testCase.High, testCase.Zero, testCase.One), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Low { get; [UsedImplicitly] init; }
        public int High { get; [UsedImplicitly] init; }
        public int Zero { get; [UsedImplicitly] init; }
        public int One { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
