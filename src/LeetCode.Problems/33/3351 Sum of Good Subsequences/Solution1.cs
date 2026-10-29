namespace LeetCode.Problems._3351_Sum_of_Good_Subsequences;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-423/submissions/detail/1448223938/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int SumOfGoodSubsequences(int[] nums)
    {
        var n = nums.Length;
        const int notStarted = int.MinValue;
        var dp = new DynamicProgramming<(int index, int last, ModNumber sum), ModNumber>((key, recursiveFunc) =>
        {
            var (index, last, sum) = key;

            if (index == n)
            {
                return sum;
            }

            var ans = recursiveFunc((index + 1, last, sum));

            var num = nums[index];

            if (last == notStarted || Math.Abs(num - last) == 1)
            {
                ans += recursiveFunc((index + 1, num, sum + num));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, notStarted, 0));
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
