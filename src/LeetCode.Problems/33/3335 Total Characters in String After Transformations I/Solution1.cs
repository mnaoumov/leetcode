namespace LeetCode.Problems._3335_Total_Characters_in_String_After_Transformations_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-421/submissions/detail/1434796810/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int LengthAfterTransformations(string s, int t)
    {
        var letterCounts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        ModNumber ans = 0;

        foreach (var (letter, count) in letterCounts)
        {
            ans += count * TransformedLettersCount(letter, t);
        }

        return ans;
    }

    private static int TransformedLettersCount(char letter, int transformationCount)
    {
        var increasesCount = 'z' - letter;
        if (transformationCount <= increasesCount)
        {
            return 1;
        }

        return TransformedLettersCount('a', transformationCount - increasesCount - 1) + TransformedLettersCount('b', transformationCount - increasesCount - 1);
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