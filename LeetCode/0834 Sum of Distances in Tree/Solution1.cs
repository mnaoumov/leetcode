using JetBrains.Annotations;

namespace LeetCode._0834_Sum_of_Distances_in_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/863906431/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SumOfDistancesInTree(int n, int[][] edges)
    {
        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        const int unset = -1;

        var depths = Enumerable.Range(0, n).Select(_ => unset).ToArray();
        var parents = Enumerable.Range(0, n).Select(_ => unset).ToArray();
        var descendantCounts = Enumerable.Range(0, n).Select(_ => unset).ToArray();

        var queue = new Queue<(int node, int depth)>();
        queue.Enqueue((0, 0));

        while (queue.Count > 0)
        {
            var (node, depth) = queue.Dequeue();

            if (depths[node] != unset)
            {
                continue;
            }

            depths[node] = depth;

            foreach (var neighbor in neighbors[node].Where(neighbor => parents[neighbor] == unset))
            {
                queue.Enqueue((neighbor, depth + 1));
                parents[neighbor] = node;
            }
        }

        foreach (var (depth, node) in depths.Select((depth, node) => (depth, node)).OrderByDescending(x => x.depth))
        {
            descendantCounts[node] = 1 + neighbors[node].Where(neighbor => depths[neighbor] == depth + 1)
                .Select(neighbor => descendantCounts[neighbor]).Sum();
        }

        var answer = new int[n];
        answer[0] = depths.Sum();

        for (var i = 1; i < n; i++)
        {
            answer[i] = answer[0] - n * depths[i];
            var previousParent = i;
            var parent = parents[i];

            for (var j = 1; j <= depths[i]; j++)
            {
                answer[i] += 2 * j * (descendantCounts[parent] - descendantCounts[previousParent]);
                (previousParent, parent) = (parent, parents[parent]);
            }
        }

        return answer;
    }
}
