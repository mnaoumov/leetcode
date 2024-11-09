namespace LeetCode.Problems._2955_Number_of_Same_End_Substrings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SameEndSubstringCount(testCase.S, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
