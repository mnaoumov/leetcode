namespace LeetCode.Problems._2698_Find_the_Punishment_Number_of_an_Integer;

/// <summary>
/// https://leetcode.com/problems/find-the-punishment-number-of-an-integer/submissions/1544447470/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PunishmentNumber(int n)
    {
        var dp = new DynamicProgramming<(int num, int partsSum), bool>((key, recursiveFunc) =>
        {
            var (num, partsSum) = key;

            if (num < partsSum)
            {
                return false;
            }

            if (num == partsSum)
            {
                return true;
            }

            var part = 0;
            var power10 = 1;

            while (true)
            {
                part += num % 10 * power10;

                if (part > partsSum)
                {
                    return false;
                }

                power10 *= 10;
                num /= 10;

                if (recursiveFunc((num, partsSum - part)))
                {
                    return true;
                }
            }
        });

        return Enumerable.Range(1, n).Where(i => i % 9 is 0 or 1).Where(i => dp.GetOrCalculate((i * i, i))).Select(i => i * i).Sum();
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
