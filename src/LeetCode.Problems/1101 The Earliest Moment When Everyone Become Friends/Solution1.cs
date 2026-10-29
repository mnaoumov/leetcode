namespace LeetCode.Problems._1101_The_Earliest_Moment_When_Everyone_Become_Friends;

/// <summary>
/// https://leetcode.com/submissions/detail/931566213/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EarliestAcq(int[][] logs, int n)
    {
        var uf = new UnionFind(n);

        foreach (var (timestamp, x, y) in logs.Select(log => (timestamp: log[0], x: log[1], y: log[2])).OrderBy(log => log.timestamp))
        {
            uf.Union(x, y);

            if (uf.ComponentsCount == 1)
            {
                return timestamp;
            }
        }

        return -1;
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
