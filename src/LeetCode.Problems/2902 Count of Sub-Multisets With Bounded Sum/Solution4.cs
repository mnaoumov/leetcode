namespace LeetCode.Problems._2902_Count_of_Sub_Multisets_With_Bounded_Sum;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-115/submissions/detail/1075086885/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    public int CountSubMultisets(IList<int> nums, int l, int r)
    {
        var counts = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var uniqueNums = counts.Keys.OrderBy(num => num).ToArray();
        var n = uniqueNums.Length;

        var dp = new DynamicProgramming<(int index, int maxSum), ModNumber>((key, recursiveFunc) =>
        {
            var (index, maxSum) = key;

            if (maxSum == 0)
            {
                return 1;
            }

            if (index == n)
            {
                return 1;
            }

            var num = uniqueNums[index];
            var count = counts[num];

            if (num == 0)
            {
                return (1 + count) * recursiveFunc((index + 1, maxSum));
            }

            var maxCount = Math.Min(count, maxSum / num);

            ModNumber ans = 0;

            for (var i = 0; i <= maxCount; i++)
            {
                ans += recursiveFunc((index + 1, maxSum - num * i));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, r)) - (l == 0 ? 0 : dp.GetOrCalculate((0, l - 1)));
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
