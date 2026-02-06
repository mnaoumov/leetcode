namespace LeetCode.Problems._3723_Maximize_Sum_of_Squares_of_Digits;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxSumOfSquares(testCase.Num, testCase.Sum), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num { get; [UsedImplicitly] init; }
        public int Sum { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
