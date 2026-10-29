namespace LeetCode.Problems._1769_Minimum_Number_of_Operations_to_Move_All_Balls_to_Each_Box;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinOperations(testCase.Boxes), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string Boxes { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
