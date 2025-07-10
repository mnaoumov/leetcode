namespace LeetCode.Problems._3607_Power_Grid_Maintenance;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-457/problems/power-grid-maintenance/submissions/1687885943/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
    {
        var uf = new UnionFind<int>();

        foreach (var connection in connections)
        {
            var u = connection[0];
            var v = connection[1];

            uf.Union(u, v);
        }

        var map = new Dictionary<int, SortedSet<int>>();

        for (var i = 1; i <= c; i++)
        {
            var root = uf.Find(i);
            map.TryAdd(root, new SortedSet<int>());
            map[root].Add(i);
        }

        var list = new List<int>();

        foreach (var query in queries)
        {
            var op = query[0];
            var x = query[1];
            var root = uf.Find(x);
            switch (op)
            {
                case 1:
                    if (map[root].Contains(x))
                    {
                        list.Add(x);
                    }
                    else if (map[root].Count > 0)
                    {
                        list.Add(map[root].Min);
                    }
                    else
                    {
                        list.Add(-1);
                    }

                    break;
                case 2:
                    map[root].Remove(x);
                    break;
            }
        }

        return list.ToArray();
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
    }
}
