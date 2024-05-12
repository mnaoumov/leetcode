using JetBrains.Annotations;

namespace LeetCode.Problems._0684_Redundant_Connection;

/// <summary>
/// https://leetcode.com/submissions/detail/931642276/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        var n = edges.Length;

        var uf = new UnionFind(n);

        foreach (var edge in edges)
        {
            var countBefore = uf.ComponentsCount;
            uf.Union(edge[0] - 1, edge[1] - 1);
            var countAfter = uf.ComponentsCount;

            if (countAfter == countBefore)
            {
                return edge;
            }
        }

        throw new InvalidOperationException();
    }

    private class UnionFind
    {
        private readonly int[] _roots;
        private readonly int[] _ranks;

        public UnionFind(int size)
        {
            _roots = Enumerable.Range(0, size).ToArray();
            _ranks = Enumerable.Repeat(1, size).ToArray();
            ComponentsCount = size;
        }

        public int ComponentsCount { get; private set; }

        private int Find(int x) => x == _roots[x] ? x : _roots[x] = Find(_roots[x]);

        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY)
            {
                return;
            }

            var rankX = _ranks[rootX];
            var rankY = _roots[rootY];

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
                _ranks[rootY]++;
            }

            ComponentsCount--;
        }
    }
}
