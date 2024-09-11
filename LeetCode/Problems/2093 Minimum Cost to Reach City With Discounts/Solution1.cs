using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2093_Minimum_Cost_to_Reach_City_With_Discounts;

/// <summary>
/// https://leetcode.com/submissions/detail/1329050179/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinimumCost(int n, int[][] highways, int discounts)
    {
        var graph = new DirectedEdgeWeightedGraph<(int node, int discountsUsed)>();
        foreach (var highway in highways)
        {
            var city1 = highway[0];
            var city2 = highway[1];
            var toll = highway[2];

            for (var discountsUsed = 0; discountsUsed <= discounts; discountsUsed++)
            {
                graph.AddEdge(new DirectedEdge<(int node, int discountsUsed)>((city1, discountsUsed),
                    (city2, discountsUsed), toll));
                graph.AddEdge(new DirectedEdge<(int node, int discountsUsed)>((city2, discountsUsed),
                    (city1, discountsUsed), toll));

                if (discountsUsed == discounts)
                {
                    continue;
                }

                var discountedToll = toll / 2;
                graph.AddEdge(new DirectedEdge<(int node, int discountsUsed)>((city1, discountsUsed),
                    (city2, discountsUsed + 1), discountedToll));
                graph.AddEdge(new DirectedEdge<(int node, int discountsUsed)>((city2, discountsUsed),
                    (city1, discountsUsed + 1), discountedToll));
            }
        }

        var dijkstra = new DijkstraDirectedShortestPath<(int node, int discountsUsed)>(graph, (0, 0));

        var arr = Enumerable.Range(0, discounts + 1).Select(discountsUsed => dijkstra.DistanceTo((n - 1, discountsUsed))).ToArray();
        var minCost = arr.Min();
        return double.IsPositiveInfinity(minCost) ? -1 : (int) minCost;
    }

    private class DijkstraDirectedShortestPath<T> where T : notnull
    {
        private readonly Dictionary<T, double> _distances = new();

        public DijkstraDirectedShortestPath(DirectedEdgeWeightedGraph<T> graph, T source)
        {
            _distances[source] = 0;
            var marked = new HashSet<T>();
            var unmarked = new HashSet<T> { source };

            while (unmarked.Count > 0)
            {
                var v = unmarked.MinBy(node => _distances[node])!;
                var dv = DistanceTo(v);

                foreach (var (_, w, weight) in graph.AdjacentEdges(v))
                {
                    if (marked.Contains(w))
                    {
                        continue;
                    }

                    var dw = DistanceTo(w);
                    var dw2 = dv + weight;

                    if (dw2 >= dw)
                    {
                        continue;
                    }

                    _distances[w] = dw2;
                    unmarked.Add(w);
                }

                marked.Add(v);
                unmarked.Remove(v);
            }
        }

        public double DistanceTo(T target) => _distances.GetValueOrDefault(target, double.PositiveInfinity);
    }

    private class DirectedEdgeWeightedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, HashSet<DirectedEdge<T>>> _adjacentEdges = new();

        public void AddEdge(DirectedEdge<T> edge)
        {
            var v = edge.From;
            var w = edge.To;
            AddNode(v);
            AddNode(w);
            _adjacentEdges[v].Add(edge);
        }

        private void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<DirectedEdge<T>>());
        public IEnumerable<DirectedEdge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<DirectedEdge<T>>());
    }

    private record DirectedEdge<T>(T From, T To, double Weight);
}
