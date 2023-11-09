using JetBrains.Annotations;

namespace LeetCode._1759_Count_Number_of_Homogenous_Substrings;

/// <summary>
/// https://leetcode.com/submissions/detail/1094840650/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountHomogenous(string s)
    {
        ModNumber ans = 0;

        var count = 0;

        for (var i = 0; i < s.Length; i++)
        {
            if (i == 0 || s[i] != s[i - 1])
            {
                count = 1;
            }
            else
            {
                count++;
            }

            ans += count;
        }

        return ans;
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
