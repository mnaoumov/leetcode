using JetBrains.Annotations;

namespace LeetCode._1420_Build_Array_Where_You_Can_Find_The_Maximum_Exactly_K_Comparisons;

/// <summary>
/// https://leetcode.com/submissions/detail/1068997456/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumOfArrays(int n, int m, int k)
    {
        var dp = new DynamicProgramming<(int itemsCount, int searchCost, int lastMax), ModNumber>((key, recursiveFunc) =>
        {
            var (itemsCount, searchCost, lastMax) = key;

            if (searchCost < 0)
            {
                return 0;
            }

            if (searchCost > itemsCount)
            {
                return 0;
            }

            if (lastMax + searchCost > m)
            {
                return 0;
            }

            if (itemsCount == 0)
            {
                return 1;
            }

            ModNumber ans = 0;

            for (var i = 1; i <= m; i++)
            {
                ans += i <= lastMax
                    ? recursiveFunc((itemsCount - 1, searchCost, lastMax))
                    : recursiveFunc((itemsCount - 1, searchCost - 1, i));
            }

            return ans;
        });

        return dp.GetOrCalculate((n, k, 0));
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
