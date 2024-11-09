namespace LeetCode.Problems._3345_Smallest_Divisible_Digit_Product_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SmallestNumber(testCase.N, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int T { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
