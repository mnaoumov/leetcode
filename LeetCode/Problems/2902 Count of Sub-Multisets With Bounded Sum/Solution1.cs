using JetBrains.Annotations;

namespace LeetCode.Problems._2902_Count_of_Sub_Multisets_With_Bounded_Sum;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-115/submissions/detail/1075076618/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountSubMultisets(IList<int> nums, int l, int r)
    {
        var counts = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var uniqueNums = counts.Keys.OrderBy(num => num).ToArray();
        var n = uniqueNums.Length;

        var dp = new DynamicProgramming<(int index, int minSum, int maxSum), ModNumber>((key, recursiveFunc) =>
        {
            var (index, minSum, maxSum) = key;

            if (index == n)
            {
                return minSum == 0 ? 1 : 0;
            }

            var num = uniqueNums[index];
            var count = counts[num];
            var maxCount = num == 0 ? count : Math.Min(count, maxSum / num);

            ModNumber ans = 0;

            for (var i = 0; i <= maxCount; i++)
            {
                var sum = num * i;
                ans += recursiveFunc((index + 1, Math.Max(0, minSum - sum), maxSum - sum));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, l, r));
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
