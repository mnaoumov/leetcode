namespace LeetCode.Problems._3302_Find_the_Lexicographically_Smallest_Valid_Sequence;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-140/submissions/detail/1405017845/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] ValidSequence(string word1, string word2)
    {
        // ReSharper disable once UseArrayEmptyMethod
        var impossible = new int[0];

        var dp = new DynamicProgramming<(int index, int digitsLeft, bool allowNonEqual), int[]>((key, recursiveFunc) =>
    {
        var (index, digitsLeft, allowNonEqual) = key;

        if (digitsLeft == 0)
        {
            return Array.Empty<int>();
        }

        if (word1.Length - index < digitsLeft)
        {
            return impossible;
        }

        if (word1[index] == word2[^digitsLeft])
        {
            var next = recursiveFunc((index + 1, digitsLeft - 1, allowNonEqual));
            return next != impossible ? new[] { index }.Concat(next).ToArray() : impossible;
        }

        // ReSharper disable once InvertIf
        if (allowNonEqual)
        {
            var next = recursiveFunc((index + 1, digitsLeft - 1, false));
            if (next != impossible)
            {
                return new[] { index }.Concat(next).ToArray();
            }
        }

        return recursiveFunc((index + 1, digitsLeft, allowNonEqual));
    });

        return dp.GetOrCalculate((0, word2.Length, true));
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
