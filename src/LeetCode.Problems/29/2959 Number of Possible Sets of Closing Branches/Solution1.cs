namespace LeetCode.Problems._2959_Number_of_Possible_Sets_of_Closing_Branches;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-119/submissions/detail/1115833706/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfSets(int n, int maxDistance, int[][] roads)
    {
        var distances = new int[n, n];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                distances[i, j] = int.MaxValue;
            }

            distances[i, i] = 0;
        }

        foreach (var road in roads)
        {
            var u = road[0];
            var v = road[1];
            var w = road[2];

            distances[u, v] = Math.Min(distances[u, v], w);
            distances[v, u] = Math.Min(distances[v, u], w);
        }

        var ans = 0;

        for (var mask = 0; mask < 1 << n; mask++)
        {
            var branches = new List<int>();

            for (var i = 0; i < n; i++)
            {
                if ((mask & 1 << i) != 0)
                {
                    branches.Add(i);
                }
            }

            var m = branches.Count;

            var graph = new EdgeWeightedGraph<int>();
            for (var j = 0; j < m; j++)
            {
                var u = branches[j];

                for (var k = j + 1; k < m; k++)
                {
                    var v = branches[k];
                    graph.AddEdge(new Edge<int>(u, v, distances[u, v]));
                }
            }

            var isValidSet = true;

            for (var j = 0; j < m; j++)
            {
                var u = branches[j];
                var sp = new DijkstraShortestPath<int>(graph, u);

                for (var k = j + 1; k < m; k++)
                {
                    var v = branches[k];

                    if (sp.DistanceTo(v) <= maxDistance)
                    {
                        continue;
                    }

                    isValidSet = false;
                    break;
                }

                if (!isValidSet)
                {
                    break;
                }
            }

            if (isValidSet)
            {
                ans++;
            }
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

        private void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<Edge<T>>());

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
