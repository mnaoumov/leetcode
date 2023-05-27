using JetBrains.Annotations;

namespace LeetCode._0995_Minimum_Number_of_K_Consecutive_Bit_Flips;

/// <summary>
/// https://leetcode.com/submissions/detail/957969916/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinKBitFlips(int[] nums, int k)
    {
        var queue = new Queue<int>();
        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (queue.Count > 0 && queue.Peek() == i)
            {
                queue.Dequeue();
            }

            var parity = (queue.Count + nums[i]) % 2;

            if (parity != 0)
            {
                continue;
            }

            if (i + k > nums.Length)
            {
                return -1;
            }

            ans++;
            queue.Enqueue(i + k);
        }

        return ans;
    }
}
