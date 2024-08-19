using JetBrains.Annotations;

namespace LeetCode.Problems._3255_Find_the_Power_of_K_Size_Subarrays_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-137/submissions/detail/1359093938/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ResultsArray(int[] nums, int k)
    {
        if (k == 1)
        {
            return nums;
        }

        var n = nums.Length;
        var ans = new int[n - k + 1];
        const int invalid = -1;

        var suffixLength = 1;

        for (var i = k - 3; i >= 0; i--)
        {
            if (nums[i] != nums[i + 1] - 1)
            {
                break;
            }

            suffixLength++;
        }

        for (var i = 0; i < n - k + 1; i++)
        {
            var lastIndex = i + k - 1;
            if (nums[lastIndex] == nums[lastIndex - 1] + 1)
            {
                suffixLength++;

                if (suffixLength > k)
                {
                    suffixLength = k;
                }
            }
            else
            {
                suffixLength = 1;
            }

            ans[i] = suffixLength == k ? nums[lastIndex] : invalid;
        }

        return ans;
    }
}
