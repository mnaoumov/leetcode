namespace LeetCode.Problems._1976_Number_of_Ways_to_Arrive_at_Destination;

/// <summary>
/// https://leetcode.com/problems/number-of-ways-to-arrive-at-destination/submissions/1582792714/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountPaths(int n, int[][] roads)
    {
        var graph = new EdgeWeightedGraph<int>();

        foreach (var road in roads)
        {
            var u = road[0];
            var v = road[1];
            var time = road[2];
            graph.AddEdge(new Edge<int>(u, v, time));
        }

        var sp = new DijkstraShortestPath<int>(graph, 0);

        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var road in roads)
        {
            var u = road[0];
            var v = road[1];
            var time = road[2];

            if ((int) sp.DistanceTo(u) + time == (int) sp.DistanceTo(v))
            {
                adjNodes[u].Add(v);
            }

            if ((int) sp.DistanceTo(v) + time == (int) sp.DistanceTo(u))
            {
                adjNodes[v].Add(u);
            }
        }

        var dp = new DynamicProgramming<int, ModNumber>((node, recursiveFunc) =>
        {
            if (node == n - 1)
            {
                return 1;
            }

            return adjNodes[node].Aggregate<int, ModNumber>(0, (current, adjNode) => current + recursiveFunc(adjNode));
        });

        return dp.GetOrCalculate(0);
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(long value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(long value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public override string ToString() => _value.ToString();
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
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
