using JetBrains.Annotations;

namespace LeetCode.Problems._1005_Maximize_Sum_Of_Array_After_K_Negations;

/// <summary>
/// https://leetcode.com/submissions/detail/914086559/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LargestSumAfterKNegations(int[] nums, int k)
    {
        var heap = new PriorityQueue<int, int>();
        var sum = 0;

        foreach (var num in nums)
        {
            heap.Enqueue(num, num);
            sum += num;
        }

        for (var i = 0; i < k; i++)
        {
            var min = heap.Dequeue();
            heap.Enqueue(-min, -min);
            sum -= 2 * min;
        }

        return sum;
    }
}
