using JetBrains.Annotations;

namespace LeetCode.Problems._2642_Design_Graph_With_Shortest_Path_Calculator;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-102/submissions/detail/934227729/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IGraph Create(int n, int[][] edges) => new Graph(n, edges);

    private class Graph : IGraph
    {
        private readonly SortedSet<(int node, int cost)>[] _adjacentNodes;
        private readonly Dictionary<(int node1, int node2), int> _minCosts = new();

        public Graph(int n, IEnumerable<int[]> edges)
        {
            var comparer = Comparer<(int node, int cost)>.Create((x1, x2) => x1.cost.CompareTo(x2.cost));

            _adjacentNodes = Enumerable.Range(0, n).Select(_ => new SortedSet<(int node, int cost)>(comparer)).ToArray();

            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public void AddEdge(int[] edge)
        {
            _adjacentNodes[edge[0]].Add((node: edge[1], cost: edge[2]));
            _minCosts.Clear();
        }

        public int ShortestPath(int node1, int node2)
        {
            if (node1 == node2)
            {
                return 0;
            }

            if (_minCosts.TryGetValue((node1, node2), out var result))
            {
                return result;
            }

            _minCosts.Clear();

            var queue = new Queue<(int node, int pathCost)>();

            queue.Enqueue((node1, 0));

            result = int.MaxValue;

            while (queue.Count > 0)
            {
                var (node, pathCost) = queue.Dequeue();

                if (node == node2)
                {
                    result = Math.Min(result, pathCost);
                    continue;
                }

                if (_minCosts.GetValueOrDefault((node1, node), int.MaxValue) <= pathCost)
                {
                    continue;
                }

                _minCosts[(node1, node)] = pathCost;

                foreach (var (adjNode, cost) in _adjacentNodes[node])
                {
                    queue.Enqueue((adjNode, pathCost + cost));
                }
            }

            if (result == int.MaxValue)
            {
                result = -1;
            }

            _minCosts[(node1, node2)] = result;
            return result;
        }
    }
}
