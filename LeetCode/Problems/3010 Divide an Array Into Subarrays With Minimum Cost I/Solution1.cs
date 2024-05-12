using JetBrains.Annotations;

namespace LeetCode._3010_Divide_an_Array_Into_Subarrays_With_Minimum_Cost_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-122/submissions/detail/1151628487/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumCost(int[] nums)
    {
        var pq = new PriorityQueue<int, int>();

        for (var i = 1; i < nums.Length; i++)
        {
            pq.Enqueue(nums[i], -nums[i]);

            if (pq.Count > 2)
            {
                pq.Dequeue();
            }
        }

        return nums[0] + pq.Dequeue() + pq.Dequeue();
    }
}
