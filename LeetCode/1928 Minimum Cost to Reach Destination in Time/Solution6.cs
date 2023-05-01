using JetBrains.Annotations;

namespace LeetCode._1928_Minimum_Cost_to_Reach_Destination_in_Time;

/// <summary>
/// https://leetcode.com/submissions/detail/942336694/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int MinCost(int maxTime, int[][] edges, int[] passingFees)
    {
        var n = passingFees.Length;
        const int unset = int.MaxValue;

        var timeGraph = new EdgeWeightedGraph<int>();

        for (var i = 0; i < n; i++)
        {
            timeGraph.AddNode(i);
        }

        foreach (var edge in edges)
        {
            timeGraph.AddEdge(new Edge<int>(edge[0], edge[1], edge[2]));
        }

        var dp = new int[n, maxTime + 1];

        for (var time = 0; time <= maxTime; time++)
        {
            for (var city = 0; city < n; city++)
            {
                dp[city, time] = unset;
            }
        }

        dp[0, 0] = passingFees[0];

        for (var time = 1; time <= maxTime; time++)
        {
            for (var city = 0; city < n; city++)
            {
                foreach (var edge in timeGraph.AdjacentEdges(city))
                {
                    var time2 = (int) edge.Weight;

                    if (time2 > time)
                    {
                        continue;
                    }

                    var previousCity = edge.Other(city);

                    if (dp[previousCity, time - time2] == unset)
                    {
                        continue;
                    }

                    dp[city, time] = Math.Min(dp[city, time], dp[previousCity, time - time2] + passingFees[city]);
                }
            }
        }

        var ans = Enumerable.Range(0, maxTime + 1).Min(time => dp[n - 1, time]);
        return ans == unset ? -1 : ans;
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
