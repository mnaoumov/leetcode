namespace LeetCode.Problems._2029_Stone_Game_IX;

/// <summary>
/// https://leetcode.com/problems/stone-game-ix/submissions/2108351769/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public bool StoneGameIX(int[] stones)
    {
        const int modulo = 3;
        var counts = new int[modulo];

        foreach (var stone in stones)
        {
            var mod = stone % modulo;
            counts[mod]++;
        }

        var dp = new DynamicProgramming<(int count0, int count1, int count2, int sumMod, bool isAliceTurn), bool>((key, getOrCalculate) =>
        {
            var (count0, count1, count2, sumMod, isAliceTurn) = key;

            if (count0 == 0 && count1 == 0 && count2 == 0)
            {
                return false;
            }

            var nextSumMode0 = sumMod;
            var nextSumMode1 = (sumMod + 1) % modulo;
            var nextSumMode2 = (sumMod + 2) % modulo;

            // ReSharper disable once DuplicatedSequentialIfBodies
            if (count0 > 0 && nextSumMode0 != 0 && getOrCalculate((count0 - 1, count1, count2, nextSumMode0, !isAliceTurn)) == isAliceTurn)
            {
                return isAliceTurn;
            }

            // ReSharper disable once DuplicatedSequentialIfBodies
            if (count1 > 0 && nextSumMode1 != 0 && getOrCalculate((count0, count1 - 1, count2, nextSumMode1, !isAliceTurn)) == isAliceTurn)
            {
                return isAliceTurn;
            }

            // ReSharper disable once DuplicatedSequentialIfBodies
            if (count2 > 0 && nextSumMode2 != 0 && getOrCalculate((count0, count1, count2 - 1, nextSumMode2, !isAliceTurn)) == isAliceTurn)
            {
                return isAliceTurn;
            }

            return !isAliceTurn;
        });

        return dp.GetOrCalculate((counts[0], counts[1], counts[2], 0, true));
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }

}
