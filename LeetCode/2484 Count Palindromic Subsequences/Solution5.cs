using JetBrains.Annotations;

namespace LeetCode._2484_Count_Palindromic_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/850728541/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
{
    public int CountPalindromes(string s)
    {
        var symbolsToIndexMap = s.Select((symbol, index) => (symbol, index))
            .ToLookup(p => p.symbol, p => p.index)
            .ToDictionary(g => g.Key, g => g.OrderBy(x => x).ToArray());

        const int modulo = 1000000007;

        var dp = new DynamicProgramming<(int index, string prefix), int>((key, recursiveFunc) =>
        {
            var (index, prefix) = key;

            if (prefix.Length == 5)
            {
                return 1;
            }

            if (index == s.Length)
            {
                return 0;
            }

            var result = 0;


            foreach (var nextIndex in GetNextIndices())
            {
                var symbol = s[nextIndex];
                result = (result + recursiveFunc((nextIndex + 1, prefix + symbol))) % modulo;
            }

            IEnumerable<int> GetNextIndices()
            {
                if (prefix.Length < 3)
                {
                    return Enumerable.Range(index, s.Length - index);
                }

                var symbolToSearch = prefix.Length == 3 ? prefix[1] : prefix[0];
                var indices = symbolsToIndexMap[symbolToSearch];

                var position = Array.BinarySearch(indices, index);

                if (position < 0)
                {
                    position = ~position;
                }

                return indices.Skip(position);
            }

            return result;
        });

        return dp.GetOrCalculate((0, ""));
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
