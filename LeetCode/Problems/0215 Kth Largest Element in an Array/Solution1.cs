using JetBrains.Annotations;

namespace LeetCode.Problems._0215_Kth_Largest_Element_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/908085542/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindKthLargest(int[] nums, int k)
    {
        var heap = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            heap.Enqueue(num, num);

            if (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        return heap.Dequeue();
    }
}
