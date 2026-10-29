namespace LeetCode.Problems._0201_Bitwise_AND_of_Numbers_Range;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RangeBitwiseAnd(testCase.Left, testCase.Right), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Left { get; [UsedImplicitly] init; }
        public int Right { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
