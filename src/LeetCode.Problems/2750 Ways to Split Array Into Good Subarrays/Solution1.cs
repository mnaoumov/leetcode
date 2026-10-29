namespace LeetCode.Problems._2750_Ways_to_Split_Array_Into_Good_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-351/submissions/detail/978972975/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int NumberOfGoodSubarraySplits(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<int, ModNumber>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 1;
            }

            var hasOne = false;

            ModNumber ans = 0;

            for (var i = index; i < n; i++)
            {
                if (nums[i] == 1)
                {
                    if (!hasOne)
                    {
                        hasOne = true;
                    }
                    else
                    {
                        break;
                    }
                }

                if (hasOne)
                {
                    ans += recursiveFunc(i + 1);
                }
            }

            return ans;
        });

        return dp.GetOrCalculate(0);
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
