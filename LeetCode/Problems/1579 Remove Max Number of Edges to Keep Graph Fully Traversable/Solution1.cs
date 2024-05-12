using JetBrains.Annotations;

namespace LeetCode._1579_Remove_Max_Number_of_Edges_to_Keep_Graph_Fully_Traversable;

/// <summary>
/// https://leetcode.com/submissions/detail/932264807/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxNumEdgesToRemove(int n, int[][] edges)
    {
        var aliceUf = new UnionFind(n);
        var bobUf = new UnionFind(n);

        var lookup = edges.Select(edge => (type: (EdgeType) edge[0], u: edge[1] - 1, v: edge[2] - 1))
            .ToLookup(edge => edge.type, edge => (edge.u, edge.v));

        var result = 0;

        AddEdges(EdgeType.Both, aliceUf, bobUf);
        AddEdges(EdgeType.AliceOnly, aliceUf);
        AddEdges(EdgeType.BobOnly, bobUf);

        return aliceUf.ComponentsCount == 1 && bobUf.ComponentsCount == 1 ? result : -1;

        void AddEdges(EdgeType type, params UnionFind[] ufs)
        {
            foreach (var (u, v) in lookup[type])
            {
                if (ufs[0].Connected(u, v))
                {
                    result++;
                }
                else
                {
                    foreach (var uf in ufs)
                    {
                        uf.Union(u, v);
                    }
                }
            }
        }
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

    private enum EdgeType
    {
        AliceOnly = 1,
        BobOnly = 2,
        Both = 3
    }
}
