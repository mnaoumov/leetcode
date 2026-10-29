namespace LeetCode.Problems._3917_Count_Indices_With_Opposite_Parity;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-500/problems/count-indices-with-opposite-parity/submissions/1993749426/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] CountOppositeParity(int[] nums)
    {
        var n = nums.Length;
        var evenPrefixCounts = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            evenPrefixCounts[i + 1] = evenPrefixCounts[i] + (nums[i] % 2 == 0 ? 1 : 0);
        }

        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            var evensCount = evenPrefixCounts[n] - evenPrefixCounts[i];
            ans[i] = nums[i] % 2 == 1 ? evensCount : (n - i) - evensCount;
        }

        return ans;
    }
}
