using JetBrains.Annotations;

namespace LeetCode._0678_Valid_Parenthesis_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1226225462/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckValidString(string s)
    {
        var dp = new DynamicProgramming<(int index, int balance), bool>((key, recursiveFunc) =>
        {
            var (index, balance) = key;

            if (balance < 0)
            {
                return false;
            }

            if (index == s.Length)
            {
                return balance == 0;
            }

            return s[index] switch
            {
                '(' => recursiveFunc((index + 1, balance + 1)),
                ')' => recursiveFunc((index + 1, balance - 1)),
                '*' => recursiveFunc((index + 1, balance))
                       || recursiveFunc((index + 1, balance + 1))
                       || recursiveFunc((index + 1, balance - 1)),
                _ => throw new NotSupportedException()
            };
        });

        return dp.GetOrCalculate((0, 0));
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
