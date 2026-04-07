namespace LeetCode.Problems._3862_Find_the_Smallest_Balanced_Index;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-492/problems/find-the-smallest-balanced-index/submissions/1941352173/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestBalancedIndex(int[] nums)
    {
        var n = nums.Length;
        var prefixSums = new long[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var suffixProduct = 1L;

        var ans = -1;

        for (var i = n - 1; i >= 0; i--)
        {
            var prefixSum = prefixSums[i];

            if (suffixProduct > prefixSum)
            {
                break;
            }

            if (suffixProduct == prefixSum)
            {
                ans = i;
            }

            suffixProduct *= nums[i];
        }

        return ans;
    }
}
