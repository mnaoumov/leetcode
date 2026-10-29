namespace LeetCode.Problems._2477_Minimum_Fuel_Cost_to_Report_to_the_Capital;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-320/submissions/detail/846656928/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public long MinimumFuelCost(int[][] roads, int seats)
    {
        var n = roads.Length + 1;

        var neighbors = Enumerable.Range(1, n).Select(_ => new HashSet<int>()).ToArray();

        foreach (var road in roads)
        {
            neighbors[road[0]].Add(road[1]);
            neighbors[road[1]].Add(road[0]);
        }

        var queue = new Queue<int>();

        for (var i = 0; i < n; i++)
        {
            if (neighbors[i].Count == 1)
            {
                queue.Enqueue(i);
            }
        }

        var cityRepresentativeCount = Enumerable.Repeat(1L, n).ToArray();

        long result = 0;

        while (queue.Count > 0)
        {
            var city = queue.Dequeue();

            if (city == 0)
            {
                continue;
            }

            result += (long) Math.Ceiling((double) cityRepresentativeCount[city] / seats);

            var neighbor = neighbors[city].Single();

            neighbors[neighbor].Remove(city);
            cityRepresentativeCount[neighbor] += cityRepresentativeCount[city];
            cityRepresentativeCount[city] = 0;
            queue.Enqueue(neighbor);
        }

        return result;
    }
}
