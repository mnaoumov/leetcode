using JetBrains.Annotations;

namespace LeetCode.Problems._1928_Minimum_Cost_to_Reach_Destination_in_Time;

/// <summary>
/// https://leetcode.com/submissions/detail/941955054/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution4 : ISolution
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

        var pq = new PriorityQueue<(int city, int time, int cost), (int cost, int time)>();
        Enqueue(0, 0, passingFees[0]);

        while (pq.Count > 0)
        {
            var (city, time, cost) = pq.Dequeue();

            if (city == n - 1)
            {
                return cost;
            }

            foreach (var edge in timeGraph.AdjacentEdges(city))
            {
                var nextTime = time + (int) edge.Weight;

                if (nextTime > maxTime)
                {
                    continue;
                }

                var nextCity = edge.Other(city);
                Enqueue(nextCity, nextTime, cost + passingFees[nextCity]);
            }
        }

        return -1;

        void Enqueue(int city, int time, int cost)
        {
            pq.Enqueue((city, time, cost), (cost, time));
        }
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

}
