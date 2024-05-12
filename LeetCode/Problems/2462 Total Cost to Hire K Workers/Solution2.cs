using JetBrains.Annotations;

namespace LeetCode.Problems._2462_Total_Cost_to_Hire_K_Workers;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-318/submissions/detail/837780703/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    private const int Empty = -1;

    public long TotalCost(int[] costs, int k, int candidates)
    {
        long result = 0;

        var firstQueue = new PriorityQueue<int, int>(new MyComparer(costs));
        var lastQueue = new PriorityQueue<int, int>(new MyComparer(costs));

        var firstQueueLastIndex = candidates - 1;
        var lastQueueFirstIndex = costs.Length - candidates;

        for (var i = 0; i < candidates; i++)
        {
            firstQueue.Enqueue(i, i);
            lastQueue.Enqueue(costs.Length - 1 - i, costs.Length - 1 - i);
        }

        for (var i = 0; i < k; i++)
        {
            var firstQueueIndex = firstQueue.Count > 0 ? firstQueue.Peek() : Empty;
            var lastQueueIndex = firstQueue.Count > 0 ? lastQueue.Peek() : Empty;

            var firstQueueCost = firstQueueIndex != Empty ? costs[firstQueueIndex] : int.MaxValue;
            var lastQueueCost = firstQueueIndex != Empty ? costs[lastQueueIndex] : int.MaxValue;

            result += Math.Min(firstQueueCost, lastQueueCost);

            if (firstQueueCost <= lastQueueCost)
            {
                firstQueue.Dequeue();
                firstQueueLastIndex++;

                if (firstQueueLastIndex < lastQueueFirstIndex)
                {
                    firstQueue.Enqueue(firstQueueLastIndex, firstQueueLastIndex);
                }

                if (firstQueueIndex != lastQueueIndex)
                {
                    continue;
                }
            }

            if (firstQueueCost < lastQueueCost)
            {
                continue;
            }

            lastQueue.Dequeue();
            lastQueueFirstIndex--;

            if (lastQueueFirstIndex > firstQueueLastIndex)
            {
                lastQueue.Enqueue(lastQueueFirstIndex, lastQueueFirstIndex);
            }
        }

        return result;
    }

    private class MyComparer : IComparer<int>
    {
        private readonly int[] _costs;

        public MyComparer(int[] costs)
        {
            _costs = costs;
        }

        public int Compare(int x, int y)
        {
            var compareValue = _costs[x].CompareTo(_costs[y]);
            return compareValue != 0 ? compareValue : x.CompareTo(y);
        }
    }
}
