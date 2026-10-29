namespace LeetCode.Problems._2361_Minimum_Costs_Using_the_Train_Line;

/// <summary>
/// https://leetcode.com/submissions/detail/1012055238/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long[] MinimumCosts(int[] regular, int[] express, int expressCost)
    {
        var n = regular.Length;
        var regularMinCost = 0L;
        var expressMinCost = expressCost + 0L;
        var ans = new long[n];

        for (var i = 1; i <= n; i++)
        {
            regularMinCost += regular[i - 1];
            expressMinCost += express[i - 1];

            regularMinCost = Math.Min(regularMinCost, expressMinCost);
            expressMinCost = Math.Min(expressMinCost, regularMinCost + expressCost);
            ans[i - 1] = regularMinCost;
        }

        return ans;
    }
}
