namespace LeetCode.Problems._3515_Shortest_Path_in_a_Weighted_Tree;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-154/problems/shortest-path-in-a-weighted-tree/submissions/1604733230/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] TreeQueries(int n, int[][] edges, int[][] queries)
    {
        var graph = new EdgeWeightedGraph<int>();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            var w = edge[2];
            graph.AddEdge(new Edge<int>(u, v, w));
        }

        var ansList = new List<int>();

        foreach (var query in queries)
        {
            switch (query[0])
            {
                case 1:
                    {
                        var u = query[1];
                        var v = query[2];
                        var wNew = query[3];
                        graph.UpdateWeight(u, v, wNew);
                        break;
                    }
                case 2:
                    {
                        var x = query[1];
                        var sp = new DijkstraShortestPath<int>(graph, 1);
                        ansList.Add((int) sp.DistanceTo(x));
                        break;
                    }
            }
        }

        return ansList.ToArray();
    }

    private class EdgeWeightedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, HashSet<Edge<T>>> _adjacentEdges = new();
        private readonly Dictionary<(T node1, T node2), Edge<T>> _edges = new();

        public void AddEdge(Edge<T> edge)
        {
            var v = edge.Either();
            var w = edge.Other(v);
            AddNode(v);
            AddNode(w);
            _adjacentEdges[v].Add(edge);
            _adjacentEdges[w].Add(edge);
            _edges[(v, w)] = edge;
            _edges[(w, v)] = edge;
        }

        public void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<Edge<T>>());

        public IEnumerable<Edge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<Edge<T>>());

        public void UpdateWeight(T u, T v, double weight)
        {
            if (!_edges.TryGetValue((u, v), out var edge))
            {
                throw new InvalidOperationException($"Edge ({u}, {v}) not found in the graph.");
            }

            _edges.Remove((u, v));
            _edges.Remove((v, u));
            _adjacentEdges[u].Remove(edge);
            _adjacentEdges[v].Remove(edge);
            AddEdge(edge with { Weight = weight });
        }
    }

    private class DijkstraShortestPath<T> where T : notnull
    {
        private readonly Dictionary<T, double> _distances = new();

        public DijkstraShortestPath(EdgeWeightedGraph<T> graph, T source)
        {
            _distances[source] = 0;
            var marked = new HashSet<T>();
            var unmarked = new PriorityQueue<T, double>();
            unmarked.Enqueue(source, 0);

            while (unmarked.Count > 0)
            {
                var v = unmarked.Dequeue();
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
                    unmarked.Enqueue(w, dw2);
                }

                marked.Add(v);
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
