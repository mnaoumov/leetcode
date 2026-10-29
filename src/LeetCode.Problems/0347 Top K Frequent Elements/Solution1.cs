namespace LeetCode.Problems._0347_Top_K_Frequent_Elements;

/// <summary>
/// https://leetcode.com/submissions/detail/908072721/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var countsMap = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var heap = new PriorityQueue<int, int>();

        foreach (var (num, count) in countsMap)
        {
            heap.Enqueue(num, count);

            if (heap.Count == k + 1)
            {
                heap.Dequeue();
            }
        }

        var result = new int[k];

        for (var i = 0; i < k; i++)
        {
            result[i] = heap.Dequeue();
        }

        return result;
    }
}
