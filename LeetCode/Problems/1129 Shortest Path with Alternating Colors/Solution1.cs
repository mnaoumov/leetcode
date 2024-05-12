using JetBrains.Annotations;

namespace LeetCode._1129_Shortest_Path_with_Alternating_Colors;

/// <summary>
/// https://leetcode.com/submissions/detail/895653607/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        var neighbors = new Dictionary<(int node, EdgeColor edgeColor), List<int>>();

        AddNeighbors(redEdges, EdgeColor.Red);
        AddNeighbors(blueEdges, EdgeColor.Blue);

        const int impossible = -1;
        var result = Enumerable.Repeat(impossible, n).ToArray();

        var queue = new Queue<(int node, EdgeColor edgeColor, int step)>();
        queue.Enqueue((0, EdgeColor.Red, 0));
        queue.Enqueue((0, EdgeColor.Blue, 0));

        var visited = new HashSet<(int node, EdgeColor edgeColor)>();

        while (queue.Count > 0)
        {
            var (node, edgeColor, step) = queue.Dequeue();

            if (!visited.Add((node, edgeColor)))
            {
                continue;
            }

            if (result[node] == impossible)
            {
                result[node] = step;
            }

            var nextColor = edgeColor == EdgeColor.Red ? EdgeColor.Blue : EdgeColor.Red;

            foreach (var nextNode in neighbors.GetValueOrDefault((node, edgeColor), new List<int>()))
            {
                queue.Enqueue((nextNode, nextColor, step + 1));
            }
        }

        return result;

        void AddNeighbors(IEnumerable<int[]> edges, EdgeColor edgeColor)
        {
            foreach (var edge in edges)
            {
                var key = (edge[0], edgeColor);

                if (!neighbors.ContainsKey(key))
                {
                    neighbors[key] = new List<int>();
                }

                neighbors[key].Add(edge[1]);
            }
        }
    }

    private enum EdgeColor
    {
        Red,
        Blue
    }
}
