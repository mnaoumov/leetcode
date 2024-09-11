namespace LeetCode.Problems._1057_Campus_Bikes;

/// <summary>
/// https://leetcode.com/submissions/detail/1089556678/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] AssignBikes(int[][] workers, int[][] bikes)
    {
        var pq = new PriorityQueue<(int workerIndex, int bikeIndex), (int distance, int bikeIndex, int workerIndex)>();

        var n = workers.Length;
        var m = bikes.Length;

        for (var workerIndex = 0; workerIndex < n; workerIndex++)
        {
            var worker = workers[workerIndex];

            for (var bikeIndex = 0; bikeIndex < m; bikeIndex++)
            {
                var bike = bikes[bikeIndex];
                var distance = Distance(worker, bike);
                pq.Enqueue((workerIndex, bikeIndex), (distance, bikeIndex, workerIndex));
            }
        }

        var ans = new int[n];
        var usedWorkers = new HashSet<int>();
        var usedBikes = new HashSet<int>();

        while (true)
        {
            var (workerIndex, bikeIndex) = pq.Dequeue();

            if (usedWorkers.Contains(workerIndex) || usedBikes.Contains(bikeIndex))
            {
                continue;
            }

            usedWorkers.Add(workerIndex);
            usedBikes.Add(bikeIndex);
            ans[workerIndex] = bikeIndex;

            if (usedWorkers.Count == n)
            {
                break;
            }
        }

        return ans;
    }

    private static int Distance(IReadOnlyList<int> worker, IReadOnlyList<int> bike) =>
        Math.Abs(worker[0] - bike[0]) + Math.Abs(worker[1] - bike[1]);
}
