using JetBrains.Annotations;

namespace LeetCode.Problems._2842_Count_K_Subsequences_of_a_String_With_Maximum_Beauty;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-112/submissions/detail/1038595352/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountKSubsequencesWithMaxBeauty(string s, int k)
    {
        var letterCounts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        if (letterCounts.Count < k)
        {
            return 0;
        }

        var maxLetterCounts = letterCounts.Values.OrderByDescending(value => value).Take(k).ToArray();

        var minCount = maxLetterCounts[^1];
        var minCountSpotsCount = 0;

        ModNumber ans = 1;

        for (var i = 0; i < k; i++)
        {
            var count = maxLetterCounts[i];
            ans *= count;

            if (count != minCount || minCountSpotsCount != 0)
            {
                continue;
            }

            minCountSpotsCount = k - i;
        }

        var minCountLetterOptionsCount = letterCounts.Values.Count(count => count == minCount);

        var chooseDp = new DynamicProgramming<(int n, int j), ModNumber>((key, recursiveFunc) =>
        {
            var (n, j) = key;

            if (j == 0)
            {
                return 1;
            }

            if (n == 0)
            {
                return 0;
            }

            return recursiveFunc((n - 1, j)) + recursiveFunc((n - 1, j - 1));
        });

        ans *= chooseDp.GetOrCalculate((minCountLetterOptionsCount, minCountSpotsCount));

        return ans;
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

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(long value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(long value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public override string ToString() => _value.ToString();
    }
}
