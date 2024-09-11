namespace LeetCode.Problems._2093_Minimum_Cost_to_Reach_City_With_Discounts;

/// <summary>
/// https://leetcode.com/submissions/detail/1329081357/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumCost(int n, int[][] highways, int discounts)
    {
        var graph = Enumerable.Range(0, n).Select(_ => new List<(int city, int toll)>()).ToArray();

        foreach (var highway in highways)
        {
            var city1 = highway[0];
            var city2 = highway[1];
            var toll = highway[2];
            graph[city1].Add((city2, toll));
            graph[city2].Add((city1, toll));
        }

        var pq = new PriorityQueue<(int city, int cost, int discountsUsed), int>();
        pq.Enqueue((0, 0, 0), 0);

        var minCosts = new int[n, discounts + 1];

        for (var city = 0; city < n; city++)
        {
            for (var discountsUsed = 0; discountsUsed <= discounts; discountsUsed++)
            {
                minCosts[city, discountsUsed] = int.MaxValue;
            }
        }

        minCosts[0, 0] = 0;

        while (pq.Count > 0)
        {
            var (city, cost, discountsUsed) = pq.Dequeue();

            if (cost > minCosts[city, discountsUsed])
            {
                continue;
            }

            foreach (var (nextCity, toll) in graph[city])
            {
                if (cost + toll < minCosts[nextCity, discountsUsed])
                {
                    minCosts[nextCity, discountsUsed] = cost + toll;
                    pq.Enqueue((nextCity, cost + toll, discountsUsed), cost + toll);
                }

                if (discountsUsed == discounts)
                {
                    continue;
                }

                var newCostWithDiscount = cost + toll / 2;

                if (newCostWithDiscount >= minCosts[nextCity, discountsUsed + 1])
                {
                    continue;
                }

                minCosts[nextCity, discountsUsed + 1] = newCostWithDiscount;
                pq.Enqueue((nextCity, newCostWithDiscount, discountsUsed + 1), newCostWithDiscount);
            }
        }

        var minCost = Enumerable.Range(0, discounts + 1).Select(discountsUsed => minCosts[n - 1, discountsUsed]).Min();
        return minCost == int.MaxValue ? -1 : minCost;
    }
}
