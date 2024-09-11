namespace LeetCode.Problems._1591_Strange_Printer_II;

/// <summary>
/// https://leetcode.com/submissions/detail/939694638/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public bool IsPrintable(int[][] targetGrid)
    {
        var m = targetGrid.Length;
        var n = targetGrid[0].Length;

        var colorRectangles = new Dictionary<int, (int top, int left, int bottom, int right)>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var color = targetGrid[i][j];
                colorRectangles.TryAdd(color, (i, j, i, j));
                var (top, left, bottom, right) = colorRectangles[color];
                colorRectangles[color] = (top: Math.Min(top, i), left: Math.Min(left, j), bottom: Math.Max(bottom, i),
                    right: Math.Max(right, j));
            }
        }

        var graph = new DirectedGraph<int>();

        foreach (var (color1, rectangle1) in colorRectangles)
        {
            graph.AddNode(color1);

            foreach (var (color2, rectangle2) in colorRectangles)
            {
                if (color1 == color2)
                {
                    continue;
                }

                var left = Math.Max(rectangle1.left, rectangle2.left);
                var top = Math.Max(rectangle1.top, rectangle2.top);
                var right = Math.Min(rectangle1.right, rectangle2.right);
                var bottom = Math.Min(rectangle1.bottom, rectangle2.bottom);

                if (left > right || top > bottom)
                {
                    continue;
                }

                for (var i = top; i <= bottom; i++)
                {
                    for (var j = left; j <= right; j++)
                    {
                        if (targetGrid[i][j] == color1)
                        {
                            graph.AddEdge(color2, color1);
                        }
                        else if (targetGrid[i][j] == color2)
                        {
                            graph.AddEdge(color1, color2);
                        }
                    }
                }
            }
        }

        var ts = new TopologicalSort<int>(graph);

        if (!ts.IsAcyclic)
        {
            return false;
        }

        var resultGrid = new int[m, n];

        foreach (var color in ts.Order)
        {
            var (left, top, right, bottom) = colorRectangles[color];

            for (var i = left; i <= right; i++)
            {
                for (var j = top; j <= bottom; j++)
                {
                    resultGrid[i, j] = color;
                }
            }
        }

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (resultGrid[i, j] != targetGrid[i][j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private class DirectedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, HashSet<T>> _adjacentNodes = new();

        public void AddEdge(T from, T to)
        {
            AddNode(from);
            AddNode(to);

            _adjacentNodes.TryAdd(from, new HashSet<T>());
            _adjacentNodes[from].Add(to);
        }

        public IEnumerable<T> Nodes => _adjacentNodes.Keys;
        public IEnumerable<T> AdjacentNodes(T node) => _adjacentNodes.GetValueOrDefault(node, new HashSet<T>());
        public void AddNode(T node) => _adjacentNodes.TryAdd(node, new HashSet<T>());
    }

    private class TopologicalSort<T> where T : notnull
    {
        private readonly HashSet<T> _seen = new();
        private readonly HashSet<T> _processing = new();
        private readonly DirectedGraph<T> _graph;
        private readonly Stack<T> _order = new();

        public TopologicalSort(DirectedGraph<T> graph)
        {
            _graph = graph;
            IsAcyclic = true;

            foreach (var node in graph.Nodes)
            {
                if (_seen.Contains(node))
                {
                    continue;
                }

                if (Dfs(node))
                {
                    continue;
                }

                IsAcyclic = false;
                break;
            }
        }

        private bool Dfs(T node)
        {
            if (!_processing.Add(node))
            {
                return false;
            }

            if (!_seen.Add(node))
            {
                return true;
            }

            if (_graph.AdjacentNodes(node).Any(adjacentNode => !Dfs(adjacentNode)))
            {
                return false;
            }

            _order.Push(node);
            _processing.Remove(node);
            return true;
        }

        public bool IsAcyclic { get; }
        public IEnumerable<T> Order => IsAcyclic ? _order : Enumerable.Empty<T>();
    }
}
