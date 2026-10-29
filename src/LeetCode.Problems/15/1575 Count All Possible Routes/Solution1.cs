namespace LeetCode.Problems._1575_Count_All_Possible_Routes;

/// <summary>
/// https://leetcode.com/submissions/detail/978884908/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountRoutes(int[] locations, int start, int finish, int fuel)
    {
        var n = locations.Length;

        var dp = new DynamicProgramming<(int cityIndex, int fuelLeft), ModNumber>((key, recursiveFunc) =>
        {
            var (cityIndex, fuelLeft) = key;

            if (fuelLeft < 0)
            {
                return 0;
            }

            ModNumber ans = cityIndex == finish ? 1 : 0;

            if (fuelLeft == 0)
            {
                return ans;
            }

            for (var j = 0; j < n; j++)
            {
                if (j == cityIndex)
                {
                    continue;
                }

                ans += recursiveFunc((j, fuelLeft - Math.Abs(locations[cityIndex] - locations[j])));
            }

            return ans;
        });

        return dp.GetOrCalculate((start, fuel));
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
