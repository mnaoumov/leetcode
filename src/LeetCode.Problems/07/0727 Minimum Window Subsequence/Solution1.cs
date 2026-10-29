namespace LeetCode.Problems._0727_Minimum_Window_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/938619832/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MinWindow(string s1, string s2)
    {
        const int impossible = int.MaxValue;

        var dp = new DynamicProgramming<(int index1, int index2), int>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;

            if (index2 == s2.Length)
            {
                return 0;
            }

            if (index1 == s1.Length)
            {
                return impossible;
            }

            var subResult = recursiveFunc((index1 + 1, index2 + (s1[index1] == s2[index2] ? 1 : 0)));
            return subResult == impossible ? impossible : 1 + subResult;
        });

        var min = Enumerable.Range(0, s1.Length).Select(index1 => (index1, length: dp.GetOrCalculate((index1, 0))))
            .Where(x => x.length != impossible).Prepend((index1: int.MaxValue, length: impossible))
            .MinBy(x => (x.length, x.index1));

        return min.length == impossible ? "" : s1.Substring(min.index1, min.length);
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
