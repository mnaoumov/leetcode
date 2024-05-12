using JetBrains.Annotations;

namespace LeetCode.Problems._2662_Minimum_Cost_of_a_Path_With_Special_Roads;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-343/submissions/detail/941882900/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumCost(int[] start, int[] target, int[][] specialRoads)
    {
        var graph = new DirectedEdgeWeightedGraph<(int x, int y)>();

        var startPoint = (start[0], start[1]);
        graph.AddNode(startPoint);
        var targetPoint = (target[0], target[1]);
        graph.AddNode(targetPoint);

        foreach (var specialRoad in specialRoads)
        {
            graph.AddEdge(new DirectedEdge<(int x, int y)>((specialRoad[0], specialRoad[1]), (specialRoad[2], specialRoad[3]),
                specialRoad[4]));
        }

        foreach (var point1 in graph.Nodes)
        {
            foreach (var point2 in graph.Nodes)
            {
                if (point2 == point1)
                {
                    continue;
                }

                var weight = Math.Abs(point1.x - point2.x) + Math.Abs(point1.y - point2.y);
                graph.AddEdge(new DirectedEdge<(int x, int y)>(point1, point2, weight));
                graph.AddEdge(new DirectedEdge<(int x, int y)>(point2, point1, weight));
            }
        }

        var sp = new DijkstraDirectedShortestPath<(int x, int y)>(graph, startPoint);
        return (int) sp.DistanceTo(targetPoint);
    }

    private record DirectedEdge<T>(T From, T To, double Weight);

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

        public void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<DirectedEdge<T>>());
        public IEnumerable<DirectedEdge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<DirectedEdge<T>>());
        public IEnumerable<T> Nodes => _adjacentEdges.Keys.ToArray();
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
}
