using JetBrains.Annotations;

namespace LeetCode._2762_Continuous_Subarrays;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long ContinuousSubarrays(int[] nums)
    {
        var ans = 0;

        var mins = new PriorityQueue<int, int>();
        var maxes = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            while (mins.Count > 0 && mins.Peek() < num - 2)
            {
                mins.Dequeue();
            }

            mins.Enqueue(num, num);

            while (maxes.Count > 0 && maxes.Peek() > num + 2)
            {
                maxes.Dequeue();
            }

            maxes.Enqueue(num, -num);

            ans += Math.Min(mins.Count, maxes.Count);
        }

        return ans;
    }
}
