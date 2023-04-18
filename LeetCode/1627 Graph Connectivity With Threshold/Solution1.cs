using JetBrains.Annotations;

namespace LeetCode._1627_Graph_Connectivity_With_Threshold;

/// <summary>
/// https://leetcode.com/problems/graph-connectivity-with-threshold/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<bool> AreConnected(int n, int threshold, int[][] queries)
    {
        var uf = new UnionFind<int>();

        var processedDivisors = new HashSet<int>();

        for (var divisor = threshold + 1; divisor <= n; divisor++)
        {
            if (!processedDivisors.Add(divisor))
            {
                continue;
            }

            for (var num = 2 * divisor; num <= n; num += divisor)
            {
                uf.Union(divisor, num);
                processedDivisors.Add(num);
            }
        }

        return queries.Select(query => uf.Connected(query[0], query[1])).ToArray();
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

        public bool Connected(T x, T y) => Find(x).Equals(Find(y));
    }
}
