namespace LeetCode.Problems._2983_Palindrome_Rearrangement_Queries;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CanMakePalindromeQueries(testCase.S, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public bool[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
