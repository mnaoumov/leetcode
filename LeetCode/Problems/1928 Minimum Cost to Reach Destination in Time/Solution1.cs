using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1928_Minimum_Cost_to_Reach_Destination_in_Time;

/// <summary>
/// https://leetcode.com/submissions/detail/941128899/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MinCost(int maxTime, int[][] edges, int[] passingFees)
    {
        var n = passingFees.Length;

        var timeGraph = new EdgeWeightedGraph<int>();

        for (var i = 0; i < n; i++)
        {
            timeGraph.AddNode(i);
        }

        foreach (var edge in edges)
        {
            timeGraph.AddEdge(new Edge<int>(edge[0], edge[1], edge[2]));
        }

        var feeGraph = new EdgeWeightedGraph<(int city, int time)>();

        const int startCity = -1;
        const int endCity = -2;

        feeGraph.AddNode((startCity, 0));

        var queue = new Queue<(int city, int time, int previousCity, int previousTime)>();
        queue.Enqueue((0, 0, startCity, 0));

        while (queue.Count > 0)
        {
            var (city, time, previousCity, previousTime) = queue.Dequeue();

            if (time > maxTime)
            {
                continue;
            }

            feeGraph.AddEdge(new Edge<(int city, int time)>((previousCity, previousTime), (city, time), passingFees[city]));

            if (city == n - 1)
            {
                feeGraph.AddEdge(new Edge<(int city, int time)>((city, time), (endCity, 0), 0));
            }

            foreach (var road in timeGraph.AdjacentEdges(city))
            {
                queue.Enqueue((road.Other(city), time + (int) road.Weight, city, time));
            }
        }

        var sp = new DijkstraShortestPath<(int city, int time)>(feeGraph, (startCity, 0));
        var distance = sp.DistanceTo((endCity, 0));
        return double.IsPositiveInfinity(distance) ? -1 : (int) distance;
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
}
