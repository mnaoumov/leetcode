namespace LeetCode.Problems._3719_Longest_Balanced_Subarray_I;

/// <summary>
/// https://leetcode.com/problems/longest-balanced-subarray-i/submissions/1915168689/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LongestBalanced(int[] nums)
    {
        var n = nums.Length;
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var evenCounts = 0;
            var oddCounts = 0;
            var seen = new HashSet<int>();

            for (var j = i; j < n; j++)
            {
                var num = nums[j];

                if (seen.Add(num))
                {
                    if (num % 2 == 0)
                    {
                        evenCounts++;
                    }
                    else
                    {
                        oddCounts++;
                    }
                }

                if (evenCounts == oddCounts)
                {
                    ans = Math.Max(ans, j - i + 1);
                }
            }
        }

        return ans;
    }
}
