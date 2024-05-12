using JetBrains.Annotations;

namespace LeetCode._3147_Taking_Maximum_Energy_From_the_Mystic_Dungeon;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-397/submissions/detail/1255688703/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaximumEnergy(int[] energy, int k)
    {
        var n = energy.Length;

        var ans = int.MinValue;

        var dp = new int[n + k];

        for (var i = n - 1; i >= 0; i--)
        {
            dp[i] = energy[i] + dp[i + k];
            ans = Math.Max(ans, dp[i]);
        }

        return ans;
    }
}
