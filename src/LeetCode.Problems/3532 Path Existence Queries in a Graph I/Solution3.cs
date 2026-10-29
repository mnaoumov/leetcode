namespace LeetCode.Problems._3532_Path_Existence_Queries_in_a_Graph_I;

/// <summary>
/// https://leetcode.com/problems/path-existence-queries-in-a-graph-i/submissions/2062242144/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
    {
        var uf = new UnionFind<int>();

        for (var i = 0; i < n - 1; i++)
        {
            if (nums[i+1] - nums[i] <= maxDiff)
            {
                uf.Union(i, i + 1);
            }
        }

        return queries.Select(arr => Answer(arr[0], arr[1])).ToArray();

        bool Answer(int u, int v) => uf.Connected(u, v);
    }

    private sealed class UnionFind<T> where T : IEquatable<T>
    {
        private readonly Dictionary<T, T> _roots = new();
        private readonly Dictionary<T, int> _ranks = new();

        private T Find(T x) => _roots.GetValueOrDefault(x, x).Equals(x) ? x : _roots[x] = Find(_roots[x]);

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
