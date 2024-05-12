using JetBrains.Annotations;

namespace LeetCode.Problems._0743_Network_Delay_Time;

/// <summary>
/// https://leetcode.com/submissions/detail/942883838/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var graph = new DirectedEdgeWeightedGraph<int>();

        for (var i = 1; i <= n; i++)
        {
            graph.AddNode(i);
        }


        foreach (var time in times)
        {
            graph.AddEdge(new DirectedEdge<int>(time[0], time[1], time[2]));
        }

        var sp = new DijkstraDirectedShortestPath<int>(graph, k);

        var ans = Enumerable.Range(1, n).Max(i => sp.DistanceTo(i));
        return double.IsPositiveInfinity(ans) ? -1 : (int) ans;
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

        public void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<DirectedEdge<T>>());
        public IEnumerable<DirectedEdge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<DirectedEdge<T>>());
    }

    private record DirectedEdge<T>(T From, T To, double Weight);
}
