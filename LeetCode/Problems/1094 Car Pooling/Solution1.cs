using JetBrains.Annotations;

namespace LeetCode.Problems._1094_Car_Pooling;

/// <summary>
/// https://leetcode.com/submissions/detail/921149265/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CarPooling(int[][] trips, int capacity)
    {
        var pq = new PriorityQueue<int, (int time, int inverseDiff)>();

        foreach (var trip in trips)
        {
            var numPassengers = trip[0];
            var from = trip[1];
            var to = trip[2];

            pq.Enqueue(-numPassengers, (from, numPassengers));
            pq.Enqueue(numPassengers, (to, -numPassengers));
        }

        while (pq.Count > 0)
        {
            var diff = pq.Dequeue();
            capacity += diff;

            if (capacity < 0)
            {
                return false;
            }
        }

        return true;
    }
}
