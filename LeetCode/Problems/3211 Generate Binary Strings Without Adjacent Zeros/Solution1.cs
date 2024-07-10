using JetBrains.Annotations;

namespace LeetCode.Problems._3211_Generate_Binary_Strings_Without_Adjacent_Zeros;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-405/submissions/detail/1312290388/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> ValidStrings(int n)
    {
        var dp = new DynamicProgramming<(int length, bool isPreviousOne), IList<string>>((key, recursiveFunc) =>
        {
            var (length, isPreviousOne) = key;

            switch (length)
            {
                case 0:
                    return new[] { "" };
                case 1:
                    return isPreviousOne ? new[] { "0", "1" } : new[] { "1" };
            }

            var ans = new List<string>();

            if (isPreviousOne)
            {
                ans.AddRange(recursiveFunc((length - 1, false)).Select(next => "0" + next));
            }

            ans.AddRange(recursiveFunc((length - 1, true)).Select(next => "1" + next));
            return ans;
        });

        return dp.GetOrCalculate((n, true));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
