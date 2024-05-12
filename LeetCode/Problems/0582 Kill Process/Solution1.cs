using JetBrains.Annotations;

namespace LeetCode._0582_Kill_Process;

/// <summary>
/// https://leetcode.com/submissions/detail/946941551/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill)
    {
        var graph = new DirectedGraph<int>();

        var n = pid.Count;

        for (var i = 0; i < n; i++)
        {
            graph.AddEdge(ppid[i], pid[i]);
        }

        var bfs = new DirectedBreadthFirstSearch<int>(graph, kill);
        return bfs.ReachableNodes.ToArray();
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

        public IEnumerable<T> AdjacentNodes(T node) => _adjacentNodes.GetValueOrDefault(node, new List<T>());
        private void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }

    private class DirectedBreadthFirstSearch<T> where T : notnull
    {
        private readonly Dictionary<T, int> _distances = new();

        public DirectedBreadthFirstSearch(DirectedGraph<T> graph, T sourceNode)
        {
            var seen = new HashSet<T>();
            var queue = new Queue<T>();
            queue.Enqueue(sourceNode);

            int count;
            var distance = 0;

            while ((count = queue.Count) > 0)
            {
                for (var i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    seen.Add(node);
                    _distances[node] = distance;

                    foreach (var adjNode in graph.AdjacentNodes(node))
                    {
                        if (seen.Contains(adjNode))
                        {
                            continue;
                        }

                        queue.Enqueue(adjNode);
                    }
                }

                distance++;
            }
        }

        public IEnumerable<T> ReachableNodes => _distances.Keys;
    }
}
