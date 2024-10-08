namespace LeetCode.Problems._0685_Redundant_Connection_II;

/// <summary>
/// https://leetcode.com/submissions/detail/932249700/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int[] FindRedundantDirectedConnection(int[][] edges)
    {
        var n = edges.Length;
        var uf = new UnionFind(n + 1);

        const int unknown = -1;
        var parents = Enumerable.Repeat(unknown, n + 1).ToArray();
        var candidate1 = new[] { unknown, unknown };
        var candidate2 = new[] { unknown, unknown };
        var lastCycleNode = new[] { unknown, unknown };

        foreach (var edge in edges)
        {
            var x = edge[0];
            var y = edge[1];

            if (uf.Connected(x, y))
            {
                if (parents[y] == unknown)
                {
                    parents[y] = x;
                }

                var parent1 = candidate1[0];

                if (parent1 == unknown)
                {
                    lastCycleNode = edge;
                    continue;
                }
            }

            uf.Union(x, y);

            if (parents[y] != unknown && parents[y] != x)
            {
                candidate1 = new[] { x, y };
                candidate2 = new[] { parents[y], y };
            }

            parents[y] = x;
        }

        if (candidate1[0] == unknown)
        {
            return lastCycleNode;
        }

        uf = new UnionFind(n + 1);

        foreach (var edge in edges)
        {
            if (edge.SequenceEqual(candidate1))
            {
                continue;
            }

            uf.Union(edge[0], edge[1]);
        }

        return uf.ComponentsCount == 2 ? candidate1 : candidate2;
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

        public bool Connected(int x, int y) => Find(x) == Find(y);
    }
}
