namespace LeetCode.Problems._1591_Strange_Printer_II;

/// <summary>
/// https://leetcode.com/submissions/detail/939247263/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool IsPrintable(int[][] targetGrid)
    {
        var m = targetGrid.Length;
        var n = targetGrid[0].Length;

        var colorRectangles = new Dictionary<int, (int left, int top, int right, int bottom)>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var color = targetGrid[i][j];
                colorRectangles.TryAdd(color, (i, j, i, j));
                var (left, top, right, bottom) = colorRectangles[color];
                colorRectangles[color] = (left: Math.Min(left, i), top: Math.Min(top, j), right: Math.Max(right, i),
                    bottom: Math.Max(bottom, j));
            }
        }

        var graph = new DirectedGraph<int>();

        foreach (var (color1, rectangle1) in colorRectangles)
        {
            foreach (var (color2, rectangle2) in colorRectangles)
            {
                if (color1 == color2)
                {
                    continue;
                }

                if (rectangle1.left >= rectangle2.left && rectangle1.right <= rectangle2.right &&
                    rectangle1.top <= rectangle2.top && rectangle1.bottom >= rectangle2.bottom)
                {
                    graph.AddEdge(color1, color2);
                }
            }
        }

        var ts = new TopologicalSort<int>(graph);
        return ts.IsAcyclic;
    }

    private class DirectedGraph<T> where T : notnull
    {
        private readonly Dictionary<T, List<T>> _adjacentNodes = new();

        public void AddEdge(T from, T to)
        {
            AddNode(from);
            AddNode(to);

            _adjacentNodes.TryAdd(from, new List<T>());
            _adjacentNodes[from].Add(to);
        }

        public IEnumerable<T> Nodes => _adjacentNodes.Keys;
        public IEnumerable<T> AdjacentNodes(T node) => _adjacentNodes.GetValueOrDefault(node, new List<T>());
        private void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }

    private class TopologicalSort<T> where T : notnull
    {
        private readonly HashSet<T> _seen = new();
        private readonly HashSet<T> _processing = new();
        private readonly DirectedGraph<T> _graph;

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

            _processing.Remove(node);
            return true;
        }

        public bool IsAcyclic { get; }
    }
}
