using JetBrains.Annotations;

namespace LeetCode._2560_House_Robber_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/892724710/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinCapability(int[] nums, int k)
    {
        var min = nums.Min();
        var max = nums.Max();

        while (min < max)
        {
            var mid = min + (max - min >> 1);

            if (CheckCapability(mid))
            {
                max = mid;
            }
            else
            {
                min = mid + 1;
            }
        }

        return min;

        bool CheckCapability(int capacity)
        {
            var houseRobbedCount = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] > capacity)
                {
                    continue;
                }

                houseRobbedCount++;
                i++;

                if (houseRobbedCount == k)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
