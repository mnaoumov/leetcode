namespace LeetCode.Problems._3903_Smallest_Stable_Index_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-498/problems/smallest-stable-index-i/submissions/1982180178/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FirstStableIndex(int[] nums, int k)
    {
        var n = nums.Length;
        var maxesLeft = new int[n];
        var minsRight = new int[n];

        maxesLeft[0] = nums[0];

        for (var i = 1; i < n; i++)
        {
            maxesLeft[i] = Math.Max(maxesLeft[i - 1], nums[i]);
        }

        minsRight[^1] = nums[^1];

        for (var i = n - 2; i >= 0; i--)
        {
            minsRight[i] = Math.Min(minsRight[i + 1], nums[i]);
        }

        for (var i = 0; i < n; i++)
        {
            var instabilityScore = maxesLeft[i] - minsRight[i];

            if (instabilityScore <= k)
            {
                return i;
            }
        }

        return -1;
    }
}
