namespace LeetCode.Problems._2548_Maximum_Price_to_Fill_a_Bag;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxPrice(testCase.Items, testCase.Capacity), Is.EqualTo(testCase.Output).Within(1e-5));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Items { get; [UsedImplicitly] init; } = null!;
        public int Capacity { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
