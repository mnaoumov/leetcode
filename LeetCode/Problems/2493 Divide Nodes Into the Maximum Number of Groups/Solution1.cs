using JetBrains.Annotations;

namespace LeetCode._2493_Divide_Nodes_Into_the_Maximum_Number_of_Groups;

/// <summary>
/// https://leetcode.com/submissions/detail/856174654/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MagnificentSets(int n, int[][] edges)
    {
        var neighbors = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            AddNeighbor(edge[0], edge[1]);
            AddNeighbor(edge[1], edge[0]);
        }

        var components = new List<List<int>>();
        var visited = new HashSet<int>();

        for (var i = 1; i <= n; i++)
        {
            var component = new List<int>();

            var queue = new Queue<int>();
            queue.Enqueue(i);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (!visited.Add(node))
                {
                    continue;
                }

                component.Add(node);

                foreach (var neighbor in neighbors[node])
                {
                    queue.Enqueue(neighbor);
                }
            }

            if (component.Count > 0)
            {
                components.Add(component);
            }
        }

        const int impossible = -1;

        var result = 0;

        foreach (var maxGroupsCount in components.Select(MaxGroupsCount))
        {
            if (maxGroupsCount == impossible)
            {
                return impossible;
            }

            result = Math.Max(result, maxGroupsCount);
        }

        return result;

        void AddNeighbor(int node1, int node2)
        {
            if (!neighbors.ContainsKey(node1))
            {
                neighbors.Add(node1, new List<int>());
            }

            neighbors[node1].Add(node2);
        }

        int MaxGroupsCount(List<int> component) => component.Max(MaxGroupsCountFromRoot);

        int MaxGroupsCountFromRoot(int root)
        {
            var visited2 = new Dictionary<int, int>();

            var queue = new Queue<(int node, int level)>();

            queue.Enqueue((root, 1));

            var maxLevel = 0;

            while (queue.Count > 0)
            {
                var (node, level) = queue.Dequeue();

                if (visited2.TryGetValue(node, out var oldLevel))
                {
                    if (level != oldLevel && level != oldLevel + 2)
                    {
                        return impossible;
                    }

                    continue;
                }

                visited2[node] = level;
                maxLevel = Math.Max(maxLevel, level);

                foreach (var neighbor in neighbors[node])
                {
                    queue.Enqueue((neighbor, level + 1));
                }
            }

            return maxLevel;
        }
    }
}
