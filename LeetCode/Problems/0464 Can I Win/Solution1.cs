namespace LeetCode.Problems._0464_Can_I_Win;

/// <summary>
/// https://leetcode.com/submissions/detail/958661226/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool CanIWin(int maxChoosableInteger, int desiredTotal)
    {
        if (desiredTotal == 0)
        {
            return true;
        }

        var allNumbersMask = (1 << maxChoosableInteger - 1) - 1;

        var dp = new DynamicProgramming<(int desiredTotal2, int chosenNumsMask), bool>((key, recursiveFunc) =>
        {
            var (desiredTotal2, chosenNumsMask) = key;

            if (desiredTotal2 <= 0)
            {
                return false;
            }

            if (chosenNumsMask == allNumbersMask)
            {
                return false;
            }

            for (var num = 1; num <= maxChoosableInteger; num++)
            {
                if ((chosenNumsMask & 1 << num - 1) != 0)
                {
                    continue;
                }

                if (!recursiveFunc((desiredTotal2 - num, chosenNumsMask | 1 << num - 1)))
                {
                    return true;
                }
            }

            return false;
        });

        return dp.GetOrCalculate((desiredTotal, 0));
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
