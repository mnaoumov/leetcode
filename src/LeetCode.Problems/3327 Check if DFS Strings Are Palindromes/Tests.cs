namespace LeetCode.Problems._3327_Check_if_DFS_Strings_Are_Palindromes;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindAnswer(testCase.Parent, testCase.S), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Parent { get; [UsedImplicitly] init; } = null!;
        public string S { get; [UsedImplicitly] init; } = null!;
        public bool[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
