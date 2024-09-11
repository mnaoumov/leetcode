using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0685_Redundant_Connection_II;

/// <summary>
/// https://leetcode.com/submissions/detail/932210149/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] FindRedundantDirectedConnection(int[][] edges)
    {
        var n = edges.Length;
        var uf = new UnionFind(n);

        foreach (var edge in edges)
        {
            var x = edge[0] - 1;
            var y = edge[1] - 1;

            if (uf.Connected(x, y))
            {
                return edge;
            }

            uf.Union(x, y);
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
        }

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
        }

        public bool Connected(int x, int y) => Find(x) == Find(y);
    }
}
