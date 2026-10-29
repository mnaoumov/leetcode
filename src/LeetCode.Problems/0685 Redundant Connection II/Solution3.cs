namespace LeetCode.Problems._0685_Redundant_Connection_II;

/// <summary>
/// https://leetcode.com/submissions/detail/932227473/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int[] FindRedundantDirectedConnection(int[][] edges)
    {
        var n = edges.Length;
        var uf = new UnionFind(n);

        const int unknown = -1;
        var parents = Enumerable.Repeat(unknown, n).ToArray();
        var child = unknown;
        var candidate1 = Array.Empty<int>();
        var candidate2 = Array.Empty<int>();

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

                var parent1 = candidate1[0] - 1;
                var node = parents[parent1];

                if (node == unknown)
                {
                    return candidate1;
                }

                while (node != parent1 && node != unknown)
                {
                    if (node == y)
                    {
                        return candidate1;
                    }

                    node = parents[node];
                }

                return candidate2;
            }

            uf.Union(x, y);

            if (parents[y] != unknown)
            {
                child = y;
                var parent1 = parents[y];
                candidate1 = new[] { parent1 + 1, child + 1 };
                candidate2 = new[] { parent1 + 1, child + 1 };
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
