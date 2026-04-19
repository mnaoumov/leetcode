namespace LeetCode.Problems._3898_Find_the_Degree_of_Each_Vertex;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindDegrees(testCase.Matrix), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Matrix { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
