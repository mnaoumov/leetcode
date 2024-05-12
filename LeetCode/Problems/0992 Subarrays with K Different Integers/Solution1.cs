using JetBrains.Annotations;

namespace LeetCode.Problems._0992_Subarrays_with_K_Different_Integers;

/// <summary>
/// https://leetcode.com/submissions/detail/1218678076/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SubarraysWithKDistinct(int[] nums, int k)
    {
        var ans = 0;
        var counts = new Dictionary<int, int>();

        var left = 0;
        var currentCount = 0;

        foreach (var num in nums)
        {
            counts.TryAdd(num, 0);
            counts[num]++;

            while (counts.Count > k)
            {
                var oldNum = nums[left];
                counts[oldNum]--;

                if (counts[oldNum] == 0)
                {
                    counts.Remove(oldNum);
                }

                left++;
                currentCount = 0;
            }

            if (counts.Count < k)
            {
                continue;
            }

            while (true)
            {
                var oldNum = nums[left];

                if (counts[oldNum] == 1)
                {
                    break;
                }

                counts[oldNum]--;
                left++;
                currentCount++;
            }

            ans += currentCount + 1;
        }

        return ans;
    }
}
