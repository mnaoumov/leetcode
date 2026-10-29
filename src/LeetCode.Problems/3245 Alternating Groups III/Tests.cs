namespace LeetCode.Problems._3245_Alternating_Groups_III;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.NumberOfAlternatingGroups(testCase.Colors, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Colors { get; [UsedImplicitly] init; } = null!;
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
