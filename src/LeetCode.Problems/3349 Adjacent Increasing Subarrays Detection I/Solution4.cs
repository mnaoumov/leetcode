namespace LeetCode.Problems._3349_Adjacent_Increasing_Subarrays_Detection_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-423/submissions/detail/1448199781/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        if (k == 1)
        {
            return true;
        }

        var n = nums.Count;
        for (var i = 0; i <= n - 2 * k; i++)
        {
            var isIncreasing = true;
            for (var j = 0; j < k - 1; j++)
            {
                if (nums[i + j] < nums[i + j + 1] && nums[i + k + j] < nums[i + k + j + 1])
                {
                    continue;
                }

                isIncreasing = false;
                break;
            }

            if (isIncreasing)
            {
                return true;
            }
        }

        return false;
    }
}
