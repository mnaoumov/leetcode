using JetBrains.Annotations;

namespace LeetCode.Problems._2473_Minimum_Cost_to_Buy_Apples;

/// <summary>
/// https://leetcode.com/submissions/detail/875146591/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long[] MinCost(int n, int[][] roads, int[] appleCost, int k)
    {
        var roadCosts = new Dictionary<(int city1, int city2), long>();
        var minPathCosts = Enumerable.Range(0, n + 1).Select(_ => new Dictionary<int, long>()).ToArray();
        var neighbors = Enumerable.Range(0, n + 1).Select(_ => new List<int>()).ToArray();

        foreach (var road in roads)
        {
            var city1 = road[0];
            var city2 = road[1];
            neighbors[city1].Add(city2);
            neighbors[city2].Add(city1);
            roadCosts[(city1, city2)] = road[2];
            roadCosts[(city2, city1)] = road[2];
        }

        var result = new long[n];

        for (var city1 = 1; city1 <= n; city1++)
        {
            minPathCosts[city1][city1] = 0;
            result[city1 - 1] = appleCost[city1 - 1];
        }

        for (var city1 = 1; city1 <= n; city1++)
        {
            var pq = new PriorityQueue<int, long>();

            foreach (var (city2, cost) in minPathCosts[city1])
            {
                pq.Enqueue(city2, cost);
            }

            var processed = new HashSet<int>();

            while (pq.Count > 0)
            {
                var city2 = pq.Dequeue();

                if (processed.Contains(city2))
                {
                    continue;
                }

                foreach (var neighbor in neighbors[city2])
                {
                    var oldCost = minPathCosts[city1].GetValueOrDefault(neighbor, int.MaxValue);
                    var newCost = Math.Min(oldCost, minPathCosts[city1][city2] + roadCosts[(city2, neighbor)]);

                    minPathCosts[city1][neighbor] = newCost;
                    minPathCosts[neighbor][city1] = newCost;
                    pq.Enqueue(neighbor, newCost);
                    result[city1 - 1] = Math.Min(result[city1 - 1], newCost * (k + 1) + appleCost[neighbor - 1]);
                }

                processed.Add(city2);
            }
        }

        return result;
    }
}
