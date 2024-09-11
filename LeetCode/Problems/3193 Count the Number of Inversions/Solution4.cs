using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3193_Count_the_Number_of_Inversions;

/// <summary>
/// https://leetcode.com/submissions/detail/1297097509/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution4 : ISolution
{
    public int NumberOfPermutations(int n, int[][] requirements)
    {
        var requirementsMap = new Dictionary<int, int>();
        foreach (var requirement in requirements)
        {
            var end = requirement[0];
            var cnt = requirement[1];

            if (cnt > end * (end + 1) / 2)
            {
                return 0;
            }

            requirementsMap[end] = cnt;
        }

        var sortedEnds = requirementsMap.Keys.OrderBy(end => end).ToArray();

        for (var i = 0; i < sortedEnds.Length - 1; i++)
        {
            if (requirementsMap[sortedEnds[i]] > requirementsMap[sortedEnds[i + 1]])
            {
                return 0;
            }
        }

        var dp = new DynamicProgramming<(int length, int inverseCount), ModNumber>((key, recursiveFunc) =>
        {
            var (length, inverseCount) = key;

            if (inverseCount > length * (length - 1) / 2)
            {
                return 0;
            }

            if (requirementsMap.TryGetValue(length - 1, out var expectedInversesCount) &&
                expectedInversesCount != inverseCount)
            {
                return 0;
            }

            if (length == 0)
            {
                return 1;
            }

            if (inverseCount == 0)
            {
                return 1;
            }

            var index = Array.BinarySearch(sortedEnds, length - 2);

            int minCount;
            var maxCount = inverseCount;
            
            if (index >= 0)
            {
                minCount = requirementsMap[sortedEnds[index]];
                maxCount = requirementsMap[sortedEnds[index]];
            }
            else
            {
                minCount = requirementsMap[sortedEnds[~index - 1]];
            }

            minCount = Math.Max(minCount, inverseCount - length + 1);

            if (minCount > maxCount)
            {
                return 0;
            }

            return ModNumber.Sum(Range(minCount, maxCount).Select(nextInverseCount => recursiveFunc((length - 1, nextInverseCount))));
        });

        return ModNumber.Sum(Range(requirementsMap[sortedEnds[^1]], n * (n - 1) / 2)
            .Select(inverseCount => dp.GetOrCalculate((n, inverseCount))));
    }

    private static IEnumerable<int> Range(int from, int to) => Enumerable.Range(from, to - from + 1);

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

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate((ModNumber) 0, (a, b) => a + b);
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
