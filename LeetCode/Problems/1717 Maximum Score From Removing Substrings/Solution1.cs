namespace LeetCode.Problems._1717_Maximum_Score_From_Removing_Substrings;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int MaximumGain(string s, int x, int y)
    {
        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == s.Length)
            {
                return 0;
            }

            var ans = recursiveFunc(index + 1);

            switch (s[index])
            {
                case 'a' when index + 1 < s.Length && s[index + 1] == 'b':
                    ans = Math.Max(ans, x + recursiveFunc(index + 2));
                    break;
                case 'b' when index + 1 < s.Length && s[index + 1] == 'a':
                    ans = Math.Max(ans, y + recursiveFunc(index + 2));
                    break;
            }

            return ans;
        });

        return dp.GetOrCalculate(0);
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

