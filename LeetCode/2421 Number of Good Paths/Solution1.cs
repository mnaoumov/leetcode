using JetBrains.Annotations;

namespace LeetCode._2421_Number_of_Good_Paths;

/// <summary>
/// https://leetcode.com/submissions/detail/878868405/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfGoodPaths(int[] vals, int[][] edges)
    {
        var n = edges.Length + 1;

        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var valueNodesMap = new SortedList<int, List<int>>();
        for (var node = 0; node < n; node++)
        {
            var value = vals[node];
            if (!valueNodesMap.ContainsKey(value))
            {
                valueNodesMap[value] = new List<int>();
            }

            valueNodesMap[value].Add(node);
        }

        var uf = new UnionFind<int>(Enumerable.Range(0, n));

        var result = 0;

        foreach (var (value, nodes) in valueNodesMap)
        {
            foreach (var node in nodes)
            {
                foreach (var neighbor in neighbors[node].Where(neighbor => vals[neighbor] <= value))
                {
                    uf.Union(node, neighbor);
                }
            }

            result += nodes.GroupBy(node => uf.Find(node)).Select(g => g.Count()).Sum(count => count * (count + 1) / 2);
        }

        return result;
    }

    private class UnionFind<T> where T : notnull
    {
        private readonly Dictionary<T, T> _parentMap = new();

        public UnionFind(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Union(item, item);
            }
        }

        public void Union(T item1, T item2)
        {
            var parent1 = Find(item1);
            var parent2 = Find(item2);

            if (Equals(parent1, parent2))
            {
                return;
            }

            _parentMap[parent1] = parent2;
        }

        public T Find(T item)
        {
            if (!_parentMap.ContainsKey(item))
            {
                _parentMap[item] = item;
            }

            if (!Equals(_parentMap[item], item))
            {
                _parentMap[item] = Find(_parentMap[item]);
            }

            return _parentMap[item];
        }
    }
}
