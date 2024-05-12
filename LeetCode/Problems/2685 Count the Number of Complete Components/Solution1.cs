using JetBrains.Annotations;

namespace LeetCode.Problems._2685_Count_the_Number_of_Complete_Components;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-345/submissions/detail/949948657/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        var uf = new UnionFind<int>();
        var componentEdgesCountMap = new Dictionary<int, int>();
        var componentVerticesCountMap = new Dictionary<int, int>();

        foreach (var edge in edges)
        {
            var root1 = uf.Find(edge[0]);
            var root2 = uf.Find(edge[1]);

            if (root1 != root2)
            {
                uf.Union(edge[0], edge[1]);
                var component = uf.Find(edge[0]);
                componentEdgesCountMap[component] = componentEdgesCountMap.GetValueOrDefault(root1) +
                                                    componentEdgesCountMap.GetValueOrDefault(root2) + 1;
                componentVerticesCountMap[component] = componentVerticesCountMap.GetValueOrDefault(root1, 1) +
                                                       componentVerticesCountMap.GetValueOrDefault(root2, 1);
            }
            else
            {
                componentEdgesCountMap[root1]++;
            }
        }

        var checkedComponents = new HashSet<int>();
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var component = uf.Find(i);

            if (!checkedComponents.Add(component))
            {
                continue;
            }

            var edgesCount = componentEdgesCountMap.GetValueOrDefault(component);
            var verticesCount = componentVerticesCountMap.GetValueOrDefault(component, 1);

            if (edgesCount == verticesCount * (verticesCount - 1) / 2)
            {
                ans++;
            }
        }

        return ans;
    }

    private class UnionFind<T> where T : IEquatable<T>
    {
        private readonly Dictionary<T, T> _roots = new();
        private readonly Dictionary<T, int> _ranks = new();

        public T Find(T x) => _roots.GetValueOrDefault(x, x).Equals(x) ? x : _roots[x] = Find(_roots[x]);

        public void Union(T x, T y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX.Equals(rootY))
            {
                return;
            }

            var rankX = GetRank(rootX);
            var rankY = GetRank(rootY);

            if (rankX < rankY)
            {
                _roots[rootX] = rootY;
            }
            else if (rankX > rankY)
            {
                _roots[rootY] = rootX;
            }
            else
            {
                _roots[rootX] = rootY;
                _ranks[rootY] = rankY + 1;
            }
        }

        private int GetRank(T x) => _ranks.GetValueOrDefault(x, 1);
    }
}
