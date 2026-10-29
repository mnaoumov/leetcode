namespace LeetCode.Problems._3108_Minimum_Cost_Walk_in_Weighted_Graph;

/// <summary>
/// https://leetcode.com/problems/minimum-cost-walk-in-weighted-graph/submissions/1579643551/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
        var uf = new UnionFind<int>();
        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            uf.Union(u, v);
        }

        var componentWeights = new Dictionary<int, int>();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var w = edge[2];
            var root = uf.Find(u);
            componentWeights.TryAdd(root, int.MaxValue);
            componentWeights[root] &= w;
        }

        return query.Select(QueryMinimumCost).ToArray();

        int QueryMinimumCost(int[] singleQuery)
        {
            var s = singleQuery[0];
            var t = singleQuery[1];
            if (s == t)
            {
                return 0;
            }
            var rootS = uf.Find(s);
            var rootT = uf.Find(t);
            if (!rootS.Equals(rootT))
            {
                return -1;
            }
            return componentWeights[rootS];
        }
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
