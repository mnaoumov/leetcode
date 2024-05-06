using JetBrains.Annotations;

namespace LeetCode._0787_Cheapest_Flights_Within_K_Stops;

/// <summary>
/// https://leetcode.com/submissions/detail/885376694/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        var flightFromMap = new Dictionary<int, List<(int to, int price)>>();

        foreach (var flight in flights)
        {
            var from = flight[0];
            var to = flight[1];
            var price = flight[2];

            if (!flightFromMap.ContainsKey(from))
            {
                flightFromMap[from] = new List<(int to, int price)>();
            }

            flightFromMap[from].Add((to, price));
        }

        var queue = new Queue<(int from, int totalPrice, int stopsCount)>();
        queue.Enqueue((src, 0, 0));

        var result = int.MaxValue;

        while (queue.Count > 0)
        {
            var (from, totalPrice, stopsCount) = queue.Dequeue();

            if (from == dst)
            {
                result = Math.Min(result, totalPrice);
                continue;
            }

            if (stopsCount > k)
            {
                continue;
            }

            if (!flightFromMap.TryGetValue(from, out var value))
            {
                continue;
            }

            foreach (var (to, price) in value)
            {
                queue.Enqueue((to, totalPrice + price, stopsCount + 1));
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}
