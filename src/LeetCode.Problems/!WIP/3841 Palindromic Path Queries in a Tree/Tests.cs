namespace LeetCode.Problems._3841_Palindromic_Path_Queries_in_a_Tree;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.PalindromePath(testCase.N, testCase.Edges, testCase.S, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public string S { get; [UsedImplicitly] init; } = null!;
        public string[] Queries { get; [UsedImplicitly] init; } = null!;
        public IList<bool> Output { get; [UsedImplicitly] init; } = null!;
    }
}
