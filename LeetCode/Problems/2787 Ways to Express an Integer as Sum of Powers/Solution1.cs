namespace LeetCode.Problems._2787_Ways_to_Express_an_Integer_as_Sum_of_Powers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-109/submissions/detail/1001068664/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int NumberOfWays(int n, int x)
    {
        var dp = new DynamicProgramming<(int num, int minItem), ModNumber>((key, recursiveFunc) =>
        {
            var (num, minItem) = key;

            if (num == 0)
            {
                return 1;
            }

            var item = minItem;

            ModNumber ans = 0;

            while (true)
            {
                var itemPowerX = Math.Pow(item, x);

                if (itemPowerX > num)
                {
                    break;
                }

                ans += recursiveFunc((num - (int) itemPowerX, item + 1));
                item++;
            }

            return ans;
        });

        return dp.GetOrCalculate((n, 1));
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

        private ModNumber(int value) => _value = value % Modulo;
        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);
    }
}
