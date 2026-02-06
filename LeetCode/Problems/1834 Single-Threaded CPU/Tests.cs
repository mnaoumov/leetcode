namespace LeetCode.Problems._1834_Single_Threaded_CPU;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GetOrder(testCase.Tasks), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Tasks { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
