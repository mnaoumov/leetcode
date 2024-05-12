using JetBrains.Annotations;

namespace LeetCode.Problems._0839_Similar_String_Groups;

/// <summary>
/// https://leetcode.com/submissions/detail/934905684/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumSimilarGroups(string[] strs)
    {
        var n = strs.Length;
        var m = strs[0].Length;

        var uf = new UnionFind(n);

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (uf.Connected(i, j))
                {
                    continue;
                }

                var diffsCount = 0;

                for (var k = 0; k < m; k++)
                {
                    if (strs[i][k] == strs[j][k])
                    {
                        continue;
                    }

                    diffsCount++;

                    if (diffsCount > 2)
                    {
                        break;
                    }
                }

                if (diffsCount > 2)
                {
                    continue;
                }

                uf.Union(i, j);
            }
        }

        return uf.ComponentsCount;
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
