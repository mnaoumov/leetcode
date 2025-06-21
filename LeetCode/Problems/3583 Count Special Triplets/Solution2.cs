using System.Numerics;

namespace LeetCode.Problems._3583_Count_Special_Triplets;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-454/problems/count-special-triplets/submissions/1664406076/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SpecialTriplets(int[] nums)
    {
        var counts = new Dictionary<int, int>();
        var n = nums.Length;

        var countsLeft = new int[n];

        for (var j = 0; j < n; j++)
        {
            var num = nums[j];
            countsLeft[j] = counts.GetValueOrDefault(2 * num);
            counts.TryAdd(num, 0);
            counts[num]++;
        }

        counts.Clear();

        ModNumber ans = 0;

        for (var j = n - 1; j >= 0; j--)
        {
            var num = nums[j];
            var countsRight = counts.GetValueOrDefault(2 * num);
            ans += (ModNumber) countsLeft[j] * countsRight;
            counts.TryAdd(num, 0);
            counts[num]++;
        }

        return ans;
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber operator /(ModNumber modNumber1, ModNumber modNumber2)
        {
            if (modNumber2 == 0)
            {
                throw new DivideByZeroException();
            }

            var inverse = Pow(modNumber2, Modulo - 2);
            return modNumber1 * inverse;
        }

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
