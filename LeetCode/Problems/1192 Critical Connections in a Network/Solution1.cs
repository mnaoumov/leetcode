using JetBrains.Annotations;

namespace LeetCode.Problems._1192_Critical_Connections_in_a_Network;

/// <summary>
/// https://leetcode.com/submissions/detail/950275822/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {
        var graph = new Graph<int>();

        for (var i = 0; i < n; i++)
        {
            graph.AddNode(i);
        }

        foreach (var connection in connections)
        {
            graph.AddEdge(connection[0], connection[1]);
        }

        var seen = new bool[n];
        var entryTimes = Enumerable.Repeat(-1, n).ToArray();
        var low = Enumerable.Repeat(-1, n).ToArray();
        var timer = 0;

        var ans = new List<IList<int>>();

        for (var i = 0; i < n; i++)
        {
            if (seen[i])
            {
                continue;
            }

            Dfs(i, -1);
        }

        return ans;

        void Dfs(int node, int parent)
        {
            seen[node] = true;
            timer++;
            entryTimes[node] = timer;
            low[node] = timer;

            foreach (var adjNode in graph.AdjacentNodes(node).Except(new[] { parent }))
            {
                if (seen[adjNode])
                {
                    low[node] = Math.Min(low[node], entryTimes[adjNode]);
                }
                else
                {
                    Dfs(adjNode, node);
                    low[node] = Math.Min(low[node], low[adjNode]);

                    if (low[adjNode] > entryTimes[node])
                    {
                        ans.Add(new[] { node, adjNode });
                    }
                }
            }
        }
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
        public void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }
}
