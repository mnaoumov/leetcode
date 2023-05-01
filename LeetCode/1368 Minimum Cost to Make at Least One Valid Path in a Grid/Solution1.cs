using JetBrains.Annotations;

namespace LeetCode._1368_Minimum_Cost_to_Make_at_Least_One_Valid_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/submissions/detail/942827176/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCost(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var graph = new DirectedEdgeWeightedGraph<(int row, int column)>();
        var deltas = new Dictionary<int, (int dRow, int dColumn)>
        {
            [1] = (0, 1),
            [2] = (0, -1),
            [3] = (1, 0),
            [4] = (-1, 0)
        };

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                foreach (var (direction, (dRow, dColumn)) in deltas)
                {
                    var nextRow = row + dRow;
                    var nextColumn = column + dColumn;

                    if (nextRow < 0 || nextColumn < 0 || nextRow >= m || nextColumn >= n)
                    {
                        continue;
                    }

                    var cost = direction == grid[row][column] ? 0 : 1;
                    graph.AddEdge(new DirectedEdge<(int row, int column)>((row, column), (nextRow, nextColumn), cost));
                }
            }
        }

        var sp = new DijkstraDirectedShortestPath<(int row, int column)>(graph, (0, 0));
        return (int) sp.DistanceTo((m - 1, n - 1));
    }

    private record DirectedEdge<T>(T From, T To, double Weight);

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

                foreach (var adjEdge in graph.AdjacentEdges(v))
                {
                    var w = adjEdge.To;

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
