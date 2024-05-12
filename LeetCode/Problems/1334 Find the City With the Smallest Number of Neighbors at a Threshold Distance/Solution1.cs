using JetBrains.Annotations;

namespace LeetCode._1334_Find_the_City_With_the_Smallest_Number_of_Neighbors_at_a_Threshold_Distance;

/// <summary>
/// https://leetcode.com/submissions/detail/968071208/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindTheCity(int n, int[][] edges, int distanceThreshold)
    {
        var graph = new EdgeWeightedGraph<int>();

        for (var i = 0; i < n; i++)
        {
            graph.AddNode(i);
        }

        foreach (var edge in edges)
        {
            graph.AddEdge(new Edge<int>(edge[0], edge[1], edge[2]));
        }

        var minReachableCount = int.MaxValue;
        var ans = -1;

        for (var i = 0; i < n; i++)
        {
            var sp = new DijkstraShortestPath<int>(graph, i);

            var reachableCount = 0;

            for (var j = 0; j < n; j++)
            {
                if (j == i)
                {
                    continue;
                }

                if (sp.DistanceTo(j) > distanceThreshold)
                {
                    continue;
                }

                reachableCount++;

                if (reachableCount > minReachableCount)
                {
                    break;
                }
            }

            if (minReachableCount < reachableCount)
            {
                continue;
            }

            minReachableCount = reachableCount;
            ans = i;
        }

        return ans;
    }

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
