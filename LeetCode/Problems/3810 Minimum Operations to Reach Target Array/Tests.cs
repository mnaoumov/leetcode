namespace LeetCode.Problems._3810_Minimum_Operations_to_Reach_Target_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinOperations(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Target { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
