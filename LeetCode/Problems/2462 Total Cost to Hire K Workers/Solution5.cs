using JetBrains.Annotations;

namespace LeetCode.Problems._2462_Total_Cost_to_Hire_K_Workers;

/// <summary>
/// https://leetcode.com/submissions/detail/908451321/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public long TotalCost(int[] costs, int k, int candidates)
    {
        var heap = new PriorityQueue<int, (int cost, int index)>();

        for (var i = 0; i < candidates; i++)
        {
            Enqueue(i);
        }

        var maxFirstIndex = candidates - 1;
        var minLastIndex = Math.Max(candidates, costs.Length - candidates);

        for (var i = costs.Length - 1; i >= minLastIndex; i--)
        {
            Enqueue(i);
        }

        var result = 0L;

        for (var i = 0; i < k; i++)
        {
            var index = heap.Dequeue();
            result += costs[index];

            if (minLastIndex - maxFirstIndex == 1)
            {
                continue;
            }

            if (index < minLastIndex)
            {
                maxFirstIndex++;
                Enqueue(maxFirstIndex);
            }
            else
            {
                minLastIndex--;
                Enqueue(minLastIndex);
            }
        }

        return result;

        void Enqueue(int i) => heap.Enqueue(i, (costs[i], i));
    }
}
