namespace LeetCode._2642_Design_Graph_With_Shortest_Path_Calculator;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-102/submissions/detail/934207947/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Graph1 : IGraph
{
    private readonly List<(int node, int cost)>[] _adjacentNodes;

    public Graph1(int n, IEnumerable<int[]> edges)
    {
        _adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<(int node, int cost)>()).ToArray();

        foreach (var edge in edges)
        {
            AddEdge(edge);
        }
    }

    public void AddEdge(int[] edge) => _adjacentNodes[edge[0]].Add((node: edge[1], cost: edge[2]));

    public int ShortestPath(int node1, int node2)
    {
        var queue = new Queue<(int node, int pathCost)>();

        queue.Enqueue((node1, 0));

        var result = int.MaxValue;

        var seen = new bool[_adjacentNodes.Length];

        while (queue.Count > 0)
        {
            var (node, pathCost) = queue.Dequeue();
            seen[node] = true;

            if (node == node2)
            {
                result = Math.Min(result, pathCost);
                continue;
            }

            foreach (var (adjNode, cost) in _adjacentNodes[node].OrderBy(x => x.cost))
            {
                if (seen[adjNode])
                {
                    continue;
                }

                queue.Enqueue((adjNode, pathCost + cost));
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}
