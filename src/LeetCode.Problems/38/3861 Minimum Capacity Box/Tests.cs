namespace LeetCode.Problems._3861_Minimum_Capacity_Box;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumIndex(testCase.Capacity, testCase.ItemSize), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Capacity { get; [UsedImplicitly] init; } = null!;
        public int ItemSize { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
