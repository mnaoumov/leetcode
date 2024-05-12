using JetBrains.Annotations;

namespace LeetCode._0815_Bus_Routes;

/// <summary>
/// https://leetcode.com/submissions/detail/939108029/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        const int sourceBus = -1;
        const int targetBus = -2;

        var graph = new Graph<int>();

        for (var i = 0; i < routes.Length; i++)
        {
            var routeSet = routes[i].ToHashSet();

            if (routeSet.Contains(source))
            {
                graph.AddEdge(sourceBus, i);
            }

            if (routeSet.Contains(target))
            {
                graph.AddEdge(targetBus, i);
            }

            for (var j = i + 1; j < routes.Length; j++)
            {
                if (routeSet.Overlaps(routes[j]))
                {
                    graph.AddEdge(i, j);
                }
            }
        }

        var bfs = new BreadthFirstSearch<int>(graph, sourceBus);
        return bfs.HasPathTo(targetBus) ? bfs.DistanceTo(targetBus) - 1 : -1;
    }

    private class BreadthFirstSearch<T> where T : notnull
    {
        private readonly Dictionary<T, int> _distances = new();

        public BreadthFirstSearch(Graph<T> graph, T sourceNode)
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

        public bool HasPathTo(T target) => _distances.ContainsKey(target);
        public int DistanceTo(T target) => _distances.GetValueOrDefault(target, -1);
    }

    private class Graph<T> where T : notnull
    {
        private readonly Dictionary<T, List<T>> _adjacentNodes = new();

        public void AddEdge(T from, T to)
        {
            AddNode(from);
            AddNode(to);

            _adjacentNodes.TryAdd(from, new List<T>());
            _adjacentNodes.TryAdd(to, new List<T>());
            _adjacentNodes[from].Add(to);
            _adjacentNodes[to].Add(from);
        }

        public IEnumerable<T> AdjacentNodes(T node) => _adjacentNodes.GetValueOrDefault(node, new List<T>());
        private void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }
}
