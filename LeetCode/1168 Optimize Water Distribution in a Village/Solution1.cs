using JetBrains.Annotations;

namespace LeetCode._1168_Optimize_Water_Distribution_in_a_Village;

/// <summary>
/// https://leetcode.com/submissions/detail/931659752/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
    {
        var result = 0;

        var weightedEdges = wells.Select((wellCost, index) => (from: 0, to: index + 1, weight: wellCost))
            .Concat(pipes.Select(pipe => (from: pipe[0], to: pipe[1], weight: pipe[2])))
            .OrderBy(edge => edge.weight)
            .ToArray();

        var uf = new UnionFind(n + 1);

        foreach (var (from, to, weight) in weightedEdges)
        {
            if (uf.Connected(from, to))
            {
                continue;
            }

            uf.Union(from, to);
            result += weight;

            if (uf.ComponentsCount == 1)
            {
                return result;
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

        public bool Connected(int from, int to) => Find(from) == Find(to);
    }
}
