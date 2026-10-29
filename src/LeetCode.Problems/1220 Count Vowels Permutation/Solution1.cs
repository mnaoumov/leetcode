namespace LeetCode.Problems._1220_Count_Vowels_Permutation;

/// <summary>
/// https://leetcode.com/submissions/detail/927286501/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountVowelPermutation(int n)
    {
        var followingMap = new Dictionary<char, char[]>
        {
            ['a'] = new[] { 'e' },
            ['e'] = new[] { 'a', 'i' },
            ['i'] = new[] { 'a', 'e', 'o', 'u' },
            ['o'] = new[] { 'i', 'u' },
            ['u'] = new[] { 'a' },
            ['\0'] = new[] { 'a', 'e', 'i', 'o', 'u' }
        };

        const int modulo = 1_000_000_007;

        var dp = new DynamicProgramming<(int lettersLeft, char previousLetter), int>((key, recursiveFunc) =>
        {
            var (lettersLeft, previousLetter) = key;
            return lettersLeft == 0
                ? 1
                : followingMap[previousLetter].Aggregate(0,
                    (current, vowel) => (current + recursiveFunc((lettersLeft - 1, vowel))) % modulo);
        });

        return dp.GetOrCalculate((n, '\0'));
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
