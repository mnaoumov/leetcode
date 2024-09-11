namespace LeetCode.Problems._2497_Maximum_Star_Sum_of_a_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/857738779/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxStarSum(int[] vals, int[][] edges, int k)
    {
        var neighbors = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            AddNeighbor(edge[0], edge[1]);
            AddNeighbor(edge[1], edge[0]);
            continue;

            void AddNeighbor(int edge1, int edge2)
            {
                if (!neighbors.ContainsKey(edge1))
                {
                    neighbors[edge1] = new List<int>();
                }

                neighbors[edge1].Add(edge2);
            }
        }

        return vals.Select((t, node) => t + neighbors.GetValueOrDefault(node, new List<int>())
                .Select(neighbor => vals[neighbor])
                .Where(val => val > 0)
                .OrderByDescending(val => val)
                .Take(k)
                .Sum())
            .Max();
    }
}
