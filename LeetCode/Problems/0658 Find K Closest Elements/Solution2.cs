using JetBrains.Annotations;

namespace LeetCode.Problems._0658_Find_K_Closest_Elements;

/// <summary>
/// https://leetcode.com/submissions/detail/908079855/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        var heap = new PriorityQueue<int, (int inverseDiff, int inverseValue)>();

        foreach (var num in arr)
        {
            heap.Enqueue(num, (-Math.Abs(num - x), -num));

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

        Array.Sort(result);

        return result;
    }
}
