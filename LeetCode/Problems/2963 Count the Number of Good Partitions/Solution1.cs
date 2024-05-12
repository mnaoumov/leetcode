using JetBrains.Annotations;

namespace LeetCode.Problems._2963_Count_the_Number_of_Good_Partitions;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-375/submissions/detail/1116174501/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int NumberOfGoodPartitions(int[] nums)
    {
        var n = nums.Length;

        var numbersUsedBeforeArr = Enumerable.Range(0, n + 1).Select(_ => new HashSet<int>()).ToArray();

        for (var i = 0; i < n - 1; i++)
        {
            numbersUsedBeforeArr[i + 1].UnionWith(numbersUsedBeforeArr[i]);
            numbersUsedBeforeArr[i + 1].Add(nums[i]);
        }

        var numbersUsedAfterArr = Enumerable.Range(0, n + 1).Select(_ => new HashSet<int>()).ToArray();

        for (var i = n - 1; i >= 0; i--)
        {
            numbersUsedAfterArr[i].UnionWith(numbersUsedAfterArr[i + 1]);
            numbersUsedAfterArr[i].Add(nums[i]);
        }

        var partitionIndices = Enumerable.Range(0, n)
            .Where(i => !numbersUsedBeforeArr[i].Overlaps(numbersUsedAfterArr[i])).ToHashSet();

        var dp = new DynamicProgramming<(int index, int partitionStartIndex), ModNumber>((key, recursiveFunc) =>
        {
            var (index, partitionStartIndex) = key;

            if (index == n)
            {
                return partitionStartIndex == n ? 1 : 0;
            }

            if (!partitionIndices.Contains(partitionStartIndex))
            {
                return 0;
            }

            return recursiveFunc((index + 1, partitionStartIndex)) + recursiveFunc((index + 1, index + 1));
        });

        return dp.GetOrCalculate((0, 0));
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
