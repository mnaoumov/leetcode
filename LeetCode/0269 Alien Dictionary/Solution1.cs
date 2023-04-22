using JetBrains.Annotations;

namespace LeetCode._0269_Alien_Dictionary;

/// <summary>
/// https://leetcode.com/submissions/detail/937677600/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public string AlienOrder(string[] words)
    {
        var graph = new DirectedGraph<char>();

        var n = words.Length;

        foreach (var letter in words.SelectMany(word => word.ToCharArray()))
        {
            graph.AddNode(letter);
        }

        for (var i = 0; i < n - 1; i++)
        {
            for (var j = 0; j < words[i].Length; j++)
            {
                if (words[i + 1].Length <= j)
                {
                    return "";
                }

                var letter = words[i][j];
                var nextWordLetter = words[i + 1][j];

                if (letter == nextWordLetter)
                {
                    continue;
                }

                graph.AddEdge(letter, nextWordLetter);
                break;
            }
        }

        var ts = new TopologicalSort<char>(graph);
        return string.Concat(ts.Order);
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
                if (!_seen.Add(node))
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

            _seen.Add(node);

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

        public void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }
}
