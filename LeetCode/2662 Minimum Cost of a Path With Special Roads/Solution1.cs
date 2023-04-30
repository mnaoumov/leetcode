using JetBrains.Annotations;

namespace LeetCode._2662_Minimum_Cost_of_a_Path_With_Special_Roads;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-343/submissions/detail/941872247/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumCost(int[] start, int[] target, int[][] specialRoads)
    {
        var graph = new EdgeWeightedGraph<(int x, int y)>();

        var startPoint = (start[0], start[1]);
        graph.AddNode(startPoint);
        var targetPoint = (target[0], target[1]);
        graph.AddNode(targetPoint);

        foreach (var specialRoad in specialRoads)
        {
            graph.AddEdge(new Edge<(int x, int y)>((specialRoad[0], specialRoad[1]), (specialRoad[2], specialRoad[3]),
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

                graph.AddEdge(new Edge<(int x, int y)>(point1, point2,
                    Math.Abs(point1.x - point2.x) + Math.Abs(point1.y - point2.y)));
            }
        }

        var sp =new DijkstraShortestPath<(int x, int y)>(graph, startPoint);
        return (int) sp.DistanceTo(targetPoint);
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
        public IEnumerable<T> Nodes => _adjacentEdges.Keys.ToArray();
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
