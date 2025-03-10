using System.Numerics;

namespace LeetCode.Problems._3470_Permutations_IV;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution3 : ISolution
{
    private readonly DynamicProgramming<int, long> _countsDp;

    public Solution3()
    {
        _countsDp = new DynamicProgramming<int, long>((n, recursiveFunc) =>
        {
            if (n == 1)
            {
                return 1;
            }

            var ans = n % 2 == 1
                ? BigInteger.One * (n + 1) / 2 * recursiveFunc(n - 1) / 2
                : BigInteger.One * n * recursiveFunc(n - 1);
            return ans < long.MaxValue ? (long) ans : long.MaxValue;
        });
    }

    public int[] Permute(int n, long k)
    {
        if (n == 1)
        {
            return new[] { 1 };
        }

        var count = _countsDp.GetOrCalculate(n - 1) / (n % 2 == 1 ? 2 : 1);
        var digitsToSkip = (int)((k - 1) / count);

        var list = new List<int>();
        var firstDigit = n % 2 == 0 ? digitsToSkip + 1 : 2 * digitsToSkip + 1;

        if (firstDigit > n)
        {
            return Array.Empty<int>();
        }

        list.Add(firstDigit);
        var nextIndex = k - digitsToSkip * count + (n % 2 == 0 && firstDigit % 2 == 1 ? 0 : 0);
        list.AddRange(Permute(n - 1, nextIndex));

        var unusedDigits = Enumerable.Range(1, n).ToHashSet();
        unusedDigits.Remove(firstDigit);
        var indexToFix = 0;

        for (var i = 1; i < n; i++)
        {
            if (firstDigit % 2 == 1)
            {
                list[i]++;
            }

            if (list[i] == firstDigit)
            {
                indexToFix = i;
            }
            else
            {
                unusedDigits.Remove(list[i]);
            }
        }

        if (indexToFix > 0)
        {
            list[indexToFix] = unusedDigits.First();
        }

        return list.ToArray();
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
