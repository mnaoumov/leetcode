namespace LeetCode.Problems._3502_Minimum_Cost_to_Reach_Every_Position;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-443/problems/minimum-cost-to-reach-every-position/submissions/1590609870/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MinCosts(int[] cost)
    {
        var n = cost.Length;
        var ans = new int[n];

        var min = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            min = Math.Min(min, cost[i]);
            ans[i] = min;
        }

        return ans;
    }
}
