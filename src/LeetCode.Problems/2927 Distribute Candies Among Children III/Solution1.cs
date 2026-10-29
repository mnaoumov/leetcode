namespace LeetCode.Problems._2927_Distribute_Candies_Among_Children_III;

/// <summary>
/// https://leetcode.com/problems/distribute-candies-among-children-iii/submissions/1650213207/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long DistributeCandies(int n, int limit) =>
        F(n + 2) - 3 * F(n - limit + 1) + 3 * F(n - 2 * limit) - F(n - 3 * limit + 1);

    private static long F(long m) => m < 0 ? 0 : m * (m - 1) / 2;
}
