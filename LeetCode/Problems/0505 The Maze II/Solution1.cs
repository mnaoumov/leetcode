using JetBrains.Annotations;

namespace LeetCode._0505_The_Maze_II;

/// <summary>
/// https://leetcode.com/submissions/detail/942891413/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ShortestDistance(int[][] maze, int[] start, int[] destination)
    {
        var m = maze.Length;
        var n = maze[0].Length;
        const int wall = 1;
        const int unset = -1;

        var graph = new DirectedEdgeWeightedGraph<(int row, int column)>();

        for (var row = 0; row < m; row++)
        {
            var leftmostEmptyColumn = unset;

            for (var column = 0; column < n; column++)
            {
                if (maze[row][column] == wall)
                {
                    leftmostEmptyColumn = unset;
                    continue;
                }

                if (leftmostEmptyColumn == unset)
                {
                    leftmostEmptyColumn = column;
                }
                else
                {
                    graph.AddEdge(new DirectedEdge<(int row, int column)>((row, column), (row, leftmostEmptyColumn),
                        column - leftmostEmptyColumn));
                }
            }

            var rightmostEmptyColumn = unset;

            for (var column = n - 1; column >= 0; column--)
            {
                if (maze[row][column] == wall)
                {
                    rightmostEmptyColumn = unset;
                    continue;
                }

                if (rightmostEmptyColumn == unset)
                {
                    rightmostEmptyColumn = column;
                }
                else
                {
                    graph.AddEdge(new DirectedEdge<(int row, int column)>((row, column), (row, rightmostEmptyColumn),
                        rightmostEmptyColumn - column));
                }
            }
        }

        for (var column = 0; column < n; column++)
        {
            var topmostEmptyRow = unset;

            for (var row = 0; row < m; row++)
            {
                if (maze[row][column] == wall)
                {
                    topmostEmptyRow = unset;
                    continue;
                }

                if (topmostEmptyRow == unset)
                {
                    topmostEmptyRow = row;
                }
                else
                {
                    graph.AddEdge(new DirectedEdge<(int row, int column)>((row, column), (topmostEmptyRow, column),
                        row - topmostEmptyRow));
                }
            }

            var bottommostEmptyRow = unset;

            for (var row = m - 1; row >= 0; row--)
            {
                if (maze[row][column] == wall)
                {
                    bottommostEmptyRow = unset;
                    continue;
                }

                if (bottommostEmptyRow == unset)
                {
                    bottommostEmptyRow = row;
                }
                else
                {
                    graph.AddEdge(new DirectedEdge<(int row, int column)>((row, column), (bottommostEmptyRow, column),
                        bottommostEmptyRow - row));
                }
            }
        }

        var sp = new DijkstraDirectedShortestPath<(int row, int column)>(graph, (start[0], start[1]));
        var ans = sp.DistanceTo((destination[0], destination[1]));
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

        private void AddNode(T node) => _adjacentEdges.TryAdd(node, new HashSet<DirectedEdge<T>>());
        public IEnumerable<DirectedEdge<T>> AdjacentEdges(T node) => _adjacentEdges.GetValueOrDefault(node, new HashSet<DirectedEdge<T>>());
    }

    private record DirectedEdge<T>(T From, T To, double Weight);
}
