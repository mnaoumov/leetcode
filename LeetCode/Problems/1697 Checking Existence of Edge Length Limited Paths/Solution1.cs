using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1697_Checking_Existence_of_Edge_Length_Limited_Paths;

/// <summary>
/// https://leetcode.com/submissions/detail/935541864/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries)
    {
        var queryObjs = queries.Select(query => (p: query[0], q: query[1], limit: query[2])).ToArray();
        var edgeObjs = edgeList.Select(edge => (u: edge[0], v: edge[1], dis: edge[2])).ToArray();

        var m = queries.Length;
        var orderedIndices = Enumerable.Range(0, m).OrderBy(i => queryObjs[i].limit).ToArray();
        var answer = new bool[m];

        var uf = new UnionFind<int>();
        var lastLimit = 0;

        foreach (var index in orderedIndices)
        {
            var (p, q, limit) = queryObjs[index];

            if (limit != lastLimit)
            {
                var previousUf = uf;
                uf = new UnionFind<int>();

                for (var i = 1; i <= n; i++)
                {
                    uf.Union(i, previousUf.Find(i));
                }

                foreach (var (u, v, dis) in edgeObjs)
                {
                    if (dis < limit)
                    {
                        uf.Union(u, v);
                    }
                }

                lastLimit = limit;
            }

            answer[index] = uf.Connected(p, q);
        }

        return answer;
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

        public bool Connected(T x, T y) => Find(x).Equals(Find(y));
    }
}
