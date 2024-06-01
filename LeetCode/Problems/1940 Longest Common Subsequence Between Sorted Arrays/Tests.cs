using JetBrains.Annotations;

namespace LeetCode.Problems._1940_Longest_Common_Subsequence_Between_Sorted_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.LongestCommonSubsequence(testCase.Arrays), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Arrays { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
