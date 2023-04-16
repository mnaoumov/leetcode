using JetBrains.Annotations;

namespace LeetCode._0721_Accounts_Merge;

/// <summary>
/// https://leetcode.com/submissions/detail/934900160/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        var uf = new UnionFind<string>();

        foreach (var account in accounts)
        {
            var firstEmail = account[1];

            foreach (var email in account.Skip(2))
            {
                uf.Union(firstEmail, email);
            }
        }

        var keyNameEmailsMap = new Dictionary<string, (string name, HashSet<string> emails)>();

        foreach (var account in accounts)
        {
            var firstEmail = account[1];
            var key = uf.Find(firstEmail);
            keyNameEmailsMap.TryAdd(key, (account[0], new HashSet<string>()));
            keyNameEmailsMap[key].emails.UnionWith(account.Skip(1));
        }

        return keyNameEmailsMap.Values.Select(x => x.emails.OrderBy(email => email, StringComparer.Ordinal).Prepend(x.name).ToArray())
            .ToArray<IList<string>>();
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
