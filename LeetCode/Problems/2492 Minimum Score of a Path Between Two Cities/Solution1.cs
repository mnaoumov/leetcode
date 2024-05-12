using JetBrains.Annotations;

namespace LeetCode.Problems._2492_Minimum_Score_of_a_Path_Between_Two_Cities;

/// <summary>
/// https://leetcode.com/submissions/detail/854561795/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinScore(int n, int[][] roads)
    {
        var neighbors = new Dictionary<int, List<int>>();
        var distances = new Dictionary<(int, int), int>();

        foreach (var road in roads)
        {
            if (!neighbors.ContainsKey(road[0]))
            {
                neighbors[road[0]] = new List<int>();
            }

            if (!neighbors.ContainsKey(road[1]))
            {
                neighbors[road[1]] = new List<int>();
            }

            neighbors[road[0]].Add(road[1]);
            neighbors[road[1]].Add(road[0]);
            distances[(road[0], road[1])] = road[2];
            distances[(road[1], road[0])] = road[2];
        }

        var queue = new Queue<(int city, int distance)>();
        queue.Enqueue((1, int.MaxValue));
        var visited = new HashSet<int>();

        var result = int.MaxValue;

        while (queue.Count > 0)
        {
            var (city, distance) = queue.Dequeue();

            result = Math.Min(result, distance);

            if (!visited.Add(city))
            {
                continue;
            }

            foreach (var neighbor in neighbors[city])
            {
                queue.Enqueue((neighbor, distances[(city, neighbor)]));
            }
        }

        return result;
    }
}
