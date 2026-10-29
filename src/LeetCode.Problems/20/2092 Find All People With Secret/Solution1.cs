namespace LeetCode.Problems._2092_Find_All_People_With_Secret;

/// <summary>
/// https://leetcode.com/submissions/detail/1185242698/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        var set = new HashSet<int> { 0, firstPerson };

        var timeGroups = meetings.Select(meeting => (x: meeting[0], y: meeting[1], time: meeting[2])).GroupBy(m => m.time)
            .OrderBy(g => g.Key);

        foreach (var timeGroup in timeGroups)
        {
            var uf = new UnionFind<int>();

            foreach (var person in set)
            {
                uf.Union(0, person);
            }

            foreach (var (x, y, _) in timeGroup)
            {
                uf.Union(x, y);
            }

            foreach (var (x, y, _) in timeGroup)
            {
                if (!uf.Connected(0, x))
                {
                    continue;
                }

                set.Add(x);
                set.Add(y);
            }
        }

        return set.ToArray();
    }

    private class UnionFind<T> where T : IEquatable<T>
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
