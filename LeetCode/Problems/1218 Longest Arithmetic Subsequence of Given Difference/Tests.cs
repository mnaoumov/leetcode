namespace LeetCode.Problems._1218_Longest_Arithmetic_Subsequence_of_Given_Difference;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestSubsequence(testCase.Arr, testCase.Difference), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr { get; [UsedImplicitly] init; } = null!;
        public int Difference { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
