namespace LeetCode.Problems._3337_Total_Characters_in_String_After_Transformations_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-421/submissions/detail/1434850028/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int LengthAfterTransformations(string s, int t, IList<int> nums)
    {
        var letterCounts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        ModNumber ans = 0;

        var dp = new DynamicProgramming<(char letter, int transformationsCount), ModNumber>((key, recursiveFunc) =>
        {
            var (letter, transformationsCount) = key;

            if (transformationsCount == 0)
            {
                return 1;
            }

            var index = letter - 'a';
            var nextLetter = letter;

            ModNumber ans2 = 0;
            for (var i = 0; i < nums[index]; i++)
            {
                nextLetter = nextLetter == 'z' ? 'a' : (char) (nextLetter + 1);
                ans2 += recursiveFunc((nextLetter, transformationsCount - 1));
            }

            return ans2;
        });

        foreach (var (letter, count) in letterCounts)
        {
            ans += count * dp.GetOrCalculate((letter, t));
        }

        return ans;
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
