namespace LeetCode.Problems._3453_Separate_Squares_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SeparateSquares(testCase.Squares), Is.EqualTo(testCase.Output).Within(1e-5));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Squares { get; [UsedImplicitly] init; } = null!;
        public double Output { get; [UsedImplicitly] init; }
    }
}
