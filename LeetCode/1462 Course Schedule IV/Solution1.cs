using JetBrains.Annotations;

namespace LeetCode._1462_Course_Schedule_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/969727385/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        var graph = new DirectedGraph<int>();

        for (var i = 0; i < numCourses; i++)
        {
            graph.AddNode(i);
        }

        foreach (var prerequisite in prerequisites)
        {
            graph.AddEdge(prerequisite[0], prerequisite[1]);
        }

        var prerequisitesMap = Enumerable.Range(0, numCourses).Select(_ => new HashSet<int>()).ToArray();
        var seen = new HashSet<int>();

        for (var i = 0; i < numCourses; i++)
        {
            Dfs(i);
        }

        return queries.Select(query => prerequisitesMap[query[0]].Contains(query[1])).ToArray();

        void Dfs(int i)
        {
            if (!seen.Add(i))
            {
                return;
            }

            foreach (var j in graph.AdjacentNodes(i))
            {
                Dfs(j);
                prerequisitesMap[i].Add(j);
                prerequisitesMap[i].UnionWith(prerequisitesMap[j]);
            }
        }
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
        public void AddNode(T node) => _adjacentNodes.TryAdd(node, new List<T>());
    }
}
