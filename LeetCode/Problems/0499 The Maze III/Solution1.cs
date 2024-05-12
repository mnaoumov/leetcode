using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0499_The_Maze_III;

/// <summary>
/// https://leetcode.com/submissions/detail/942961271/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string? FindShortestWay(int[][] maze, int[] ball, int[] hole)
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
                else if (row == hole[0] && leftmostEmptyColumn <= hole[1] && hole[1] <= column)
                {
                    AddEdge(row, column, row, hole[1]);
                }
                else
                {
                    AddEdge(row, column, row, leftmostEmptyColumn);
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
                else if (row == hole[0] && column <= hole[1] && hole[1] <= rightmostEmptyColumn)
                {
                    AddEdge(row, column, row, hole[1]);
                }
                else
                {
                    AddEdge(row, column, row, rightmostEmptyColumn);
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
                else if (column == hole[1] && topmostEmptyRow <= hole[0] && hole[0] <= row)
                {
                    AddEdge(row, column, hole[0], column);
                }
                else
                {
                    AddEdge(row, column, topmostEmptyRow, column);
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
                else if (column == hole[1] && row <= hole[0] && hole[0] <= bottommostEmptyRow)
                {
                    AddEdge(row, column, hole[0], column);
                }
                else
                {
                    AddEdge(row, column, bottommostEmptyRow, column);
                }
            }
        }


        var sp = new DijkstraDirectedShortestPath<(int row, int column)>(graph, (ball[0], ball[1]));
        var distance = sp.DistanceTo((hole[0], hole[1]));

        return double.IsPositiveInfinity(distance)
            ? "impossible"
            : sp.ShortestPaths((hole[0], hole[1])).Min(BuildString);

        void AddEdge(int row1, int column1, int row2, int column2)
        {
            if (row1 == row2 && column1 == column2)
            {
                return;
            }

            graph.AddEdge(new DirectedEdge<(int row, int column)>((row1, column1), (row2, column2),
                Math.Abs(row1 - row2) + Math.Abs(column1 - column2)));
        }
    }

    private static string BuildString((int row, int column)[] path)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < path.Length - 1; i++)
        {
            var (row, column) = path[i];
            var (nextRow, nextColumn) = path[i + 1];

            if (row == nextRow)
            {
                sb.Append(column < nextColumn ? 'r' : 'l');
            }
            else
            {
                sb.Append(row < nextRow ? 'd' : 'u');
            }
        }

        return sb.ToString();
    }

    private class DijkstraDirectedShortestPath<T> where T : notnull
    {
        private readonly T _source;
        private const double Epsilon = 1e-5;
        private readonly Dictionary<T, double> _distances = new();
        private readonly Dictionary<T, List<T>> _previousNodes = new();

        public DijkstraDirectedShortestPath(DirectedEdgeWeightedGraph<T> graph, T source)
        {
            _source = source;
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

                    if (dw2 > dw + Epsilon)
                    {
                        continue;
                    }

                    _previousNodes.TryAdd(w, new List<T>());

                    if (Math.Abs(dw2 - dw) <= Epsilon)
                    {
                        _previousNodes[w].Add(v);
                        continue;
                    }

                    _previousNodes[w] = new List<T> { v };
                    _distances[w] = dw2;
                    unmarked.Add(w);
                }

                marked.Add(v);
                unmarked.Remove(v);
            }
        }

        public double DistanceTo(T target) => _distances.GetValueOrDefault(target, double.PositiveInfinity);

        public IEnumerable<T[]> ShortestPaths(T target)
        {
            var ans = new List<T[]>();

            if (double.IsPositiveInfinity(DistanceTo(target)))
            {
                return ans;
            }

            var list = new List<T>();

            Backtrack(target);

            return ans;

            void Backtrack(T node)
            {
                list.Add(node);

                if (Equals(node, _source))
                {
                    ans.Add(list.Reverse<T>().ToArray());
                }
                else
                {
                    foreach (var previous in _previousNodes[node])
                    {
                        Backtrack(previous);
                    }
                }

                list.RemoveAt(list.Count - 1);
            }
        }
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
