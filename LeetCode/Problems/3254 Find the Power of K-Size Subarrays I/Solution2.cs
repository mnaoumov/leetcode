namespace LeetCode.Problems._3254_Find_the_Power_of_K_Size_Subarrays_I;

/// <summary>
/// https://leetcode.com/submissions/detail/1359060991/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] ResultsArray(int[] nums, int k)
    {
        var n = nums.Length;
        var ans = new int[n - k + 1];
        const int invalid = -1;

        for (var i = 0; i < n - k + 1; i++)
        {
            var lastIndex = i + k - 1;
            bool isSequential;

            if (i > 0 && k > 1 && ans[i - 1] != invalid)
            {
                isSequential = nums[lastIndex] == nums[lastIndex - 1] + 1;
            }
            else
            {
                isSequential = true;
                for (var j = 1; j < k; j++)
                {
                    if (nums[i + j] == nums[i + j - 1] + 1)
                    {
                        continue;
                    }

                    isSequential = false;
                    break;
                }
            }

            ans[i] = isSequential ? nums[lastIndex] : invalid;
        }

        return ans;
    }
}
