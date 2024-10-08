namespace LeetCode.Problems._0685_Redundant_Connection_II;

/// <summary>
/// https://leetcode.com/submissions/detail/932223254/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int[] FindRedundantDirectedConnection(int[][] edges)
    {
        var n = edges.Length;
        var uf = new UnionFind(n);

        const int unknown = -1;
        var parents = Enumerable.Repeat(unknown, n).ToArray();
        var parent1 = unknown;
        var parent2 = unknown;
        var child = unknown;

        foreach (var edge in edges)
        {
            var x = edge[0] - 1;
            var y = edge[1] - 1;

            if (uf.Connected(x, y))
            {
                if (child == unknown)
                {
                    return edge;
                }

                var node = parents[parent1];

                while (node != parent1 && node != unknown)
                {
                    if (node == y)
                    {
                        return new[] { parent1 + 1, child + 1 };
                    }

                    node = parents[node];
                }

                return new[] { parent2 + 1, child + 1 };
            }

            uf.Union(x, y);

            if (parents[y] != unknown)
            {
                child = y;
                parent1 = parents[y];
                parent2 = x;
            }

            parents[y] = x;
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
