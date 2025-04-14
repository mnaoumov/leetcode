namespace LeetCode.Problems._3493_Properties_Graph;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-442/problems/properties-graph/submissions/1582832472/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfComponents(int[][] properties, int k)
    {
        var sets = properties.Select(arr => arr.ToHashSet()).ToArray();

        var n = properties.Length;

        var uf = new UnionFind<int>();

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (sets[i].Intersect(sets[j]).Count() >= k)
                {
                    uf.Union(i, j);
                }
            }
        }

        var components = new HashSet<int>();

        for (var i = 0; i < n; i++)
        {
            components.Add(uf.Find(i));
        }

        return components.Count;
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
