using JetBrains.Annotations;

namespace LeetCode.Problems._2699_Modify_Graph_Edge_Weights;

/// <summary>
/// https://leetcode.com/submissions/detail/1374878030/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
    {
        const int unset = -1;
        const int maxValue = 2_000_000_000;

        var graph = new EdgeWeightedGraph<int>();

        for (var i = 0; i < n; i++)
        {
            graph.AddNode(i);
        }

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            var weight = edge[2];

            if (weight != unset)
            {
                graph.AddEdge(new Edge<int>(u, v, weight));
            }
        }

        var sp = new DijkstraShortestPath<int>(graph, source);
        var minDistance = ToInt(sp.DistanceTo(destination));

        if (minDistance < target)
        {
            return Array.Empty<int[]>();
        }

        var found = minDistance == target;

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            var weight = edge[2];

            if (weight != unset)
            {
                continue;
            }

            edge[2] = found ? maxValue : 1;

            if (found)
            {
                continue;
            }

            graph.AddEdge(new Edge<int>(u, v, edge[2]));
            sp = new DijkstraShortestPath<int>(graph, source);
            var newMinDistance = ToInt(sp.DistanceTo(destination));

            if (newMinDistance > target)
            {
                continue;
            }

            edge[2] += target - newMinDistance;
            found = true;
        }

        return found ? edges : Array.Empty<int[]>();
    }

    private static int ToInt(double value) => value >= int.MaxValue ? int.MaxValue : (int) value;

    private class EdgeWeightedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, HashSet<Edge<T>>> _adjacentEdges = new();

        public void AddEdge(Edge<T> edge)
        {
            var v = edge.Either();
            var w = edge.Other(v);
            AddNode(v);
            AddNode(w);
            _adjacentEdges[v].Add(edge);
            _adjacentEdges[w].Add(edge);
        }

        public void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<Edge<T>>());

        public IEnumerable<Edge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<Edge<T>>());
    }

    private class DijkstraShortestPath<T> where T : notnull
    {
        private readonly Dictionary<T, double> _distances = new();

        public DijkstraShortestPath(EdgeWeightedGraph<T> graph, T source)
        {
            _distances[source] = 0;
            var marked = new HashSet<T>();
            var unmarked = new HashSet<T> { source };

            while (unmarked.Count > 0)
            {
                var v = unmarked.MinBy(node => _distances[node])!;
                var dv = DistanceTo(v);

                foreach (var adjEdge in graph.AdjacentEdges(v))
                {
                    var w = adjEdge.Other(v);

                    if (marked.Contains(w))
                    {
                        continue;
                    }

                    var dw = DistanceTo(w);
                    var dw2 = dv + adjEdge.Weight;

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

    private record Edge<T>(T Node1, T Node2, double Weight)
    {
        public T Either() => Node1;

        public T Other(T node)
        {
            if (Equals(node, Node1))
            {
                return Node2;
            }

            if (Equals(node, Node2))
            {
                return Node1;
            }

            throw new InvalidOperationException();
        }
    }
}
