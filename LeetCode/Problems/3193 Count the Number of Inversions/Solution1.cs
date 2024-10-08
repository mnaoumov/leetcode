namespace LeetCode.Problems._3193_Count_the_Number_of_Inversions;

/// <summary>
/// https://leetcode.com/submissions/detail/1297031919/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumberOfPermutations(int n, int[][] requirements)
    {
        var requirementsMap = new Dictionary<int, int>();
        foreach (var requirement in requirements)
        {
            requirementsMap[requirement[0]] = requirement[1];
        }

        var dp = new DynamicProgramming<(int length, int inversesCount), ModNumber>((key, recursiveFunc) =>
        {
            var (length, inversesCount) = key;

            if (inversesCount > length * (length - 1) / 2)
            {
                return 0;
            }

            if (requirementsMap.TryGetValue(length - 1, out var expectedInversesCount) &&
                expectedInversesCount != inversesCount)
            {
                return 0;
            }

            if (length == 0)
            {
                return 1;
            }

            return Enumerable.Range(0, inversesCount + 1).Select(x => recursiveFunc((length - 1, x)))
                .Aggregate((a, b) => a + b);
        });

        return dp.GetOrCalculate((n + 1, n * (n - 1) / 2));
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
