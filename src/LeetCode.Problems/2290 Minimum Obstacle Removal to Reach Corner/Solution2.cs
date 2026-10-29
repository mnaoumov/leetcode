namespace LeetCode.Problems._2290_Minimum_Obstacle_Removal_to_Reach_Corner;

/// <summary>
/// https://leetcode.com/submissions/detail/1464656858/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MinimumObstacles(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var graph = new DirectedEdgeWeightedGraph<(int row, int column)>();

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                AddEdge((row, column), (row: row - 1, column));
                AddEdge((row, column), (row, column: column - 1));
            }
        }

        var sp = new DijkstraDirectedShortestPath<(int row, int column)>(graph, (0, 0));
        return (int) sp.DistanceTo((m - 1, n - 1));

        void AddEdge((int row, int column) cell1, (int row, int column) cell2)
        {
            if (!IsValid(cell1) || !IsValid(cell2))
            {
                return;
            }

            graph.AddEdge(new DirectedEdge<(int row, int column)>(cell1, cell2, IsObstacle(cell2) ? 1 : 0));
            graph.AddEdge(new DirectedEdge<(int row, int column)>(cell2, cell1, IsObstacle(cell1) ? 1 : 0));
        }

        bool IsValid((int row, int column) cell) =>
            cell.row >= 0 && cell.row < m && cell.column >= 0 && cell.column < n;


        bool IsObstacle((int row, int column) cell) => grid[cell.row][cell.column] == 1;
    }

    private class DijkstraDirectedShortestPath<T> where T : notnull
    {
        private readonly Dictionary<T, double> _distances = new();

        public DijkstraDirectedShortestPath(DirectedEdgeWeightedGraph<T> graph, T source)
        {
            _distances[source] = 0;
            var marked = new HashSet<T>();
            var unmarked = new PriorityQueue<T, double>();
            unmarked.Enqueue(source, 0);

            while (unmarked.Count > 0)
            {
                var v = unmarked.Dequeue();
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
                    unmarked.Enqueue(w, dw2);
                }

                marked.Add(v);
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

        private void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<DirectedEdge<T>>());
        public IEnumerable<DirectedEdge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<DirectedEdge<T>>());
    }

    private record DirectedEdge<T>(T From, T To, double Weight);
}
