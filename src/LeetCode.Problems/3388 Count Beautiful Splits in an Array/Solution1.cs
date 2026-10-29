using System.Numerics;

namespace LeetCode.Problems._3388_Count_Beautiful_Splits_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1479099997/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int BeautifulSplits(int[] nums)
    {
        var n = nums.Length;
        ModNumber multiplier = 23;
        var multiplierInverse = multiplier.Inverse();

        if (n < 3)
        {
            return 0;
        }

        var ans = 0;

        var prefixHashes = new ModNumber[n + 1];
        prefixHashes[0] = 0;
        ModNumber multiplierPowered = 1;
        for (var i = 0; i < n; i++)
        {
            prefixHashes[i + 1] = prefixHashes[i] + nums[i] * multiplierPowered;
            multiplierPowered *= multiplier;
        }

        for (var i = 1; i < n / 2; i++)
        {
            if (IsEqualToPrefix(i, i))
            {
                ans = n - 2 * i;
            }
        }

        for (var j = 2; j < n; j++)
        {
            var maxI = Math.Min(j - 1, n - j);
            for (var i = 1; i <= maxI; i++)
            {
                if (IsEqualToPrefix(j, i) && !IsEqualToPrefix(i, i))
                {
                    ans++;
                }
            }
        }


        return ans;

        bool IsEqualToPrefix(int startIndex, int length)
        {
            var hash1 = GetHash(0, length);
            var hash2 = GetHash(startIndex, length);

            if (hash1 != hash2)
            {
                return false;
            }

            for (var i = 0; i < length; i++)
            {
                if (nums[startIndex + i] != nums[i])
                {
                    return false;
                }
            }

            return true;
        }

        int GetHash(int startIndex, int length)
        {
            return (prefixHashes[startIndex + length] - prefixHashes[startIndex]) *
                   ModNumber.Pow(multiplierInverse, startIndex);
        }
    }

    private class ModNumber
    {
        private const int Modulus = 1_000_000_007;
        private readonly int _value;

        private ModNumber(long value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulus);

        private static int Mod(long value) => (int) (value % Modulus);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator ModNumber(BigInteger value) => new((int) (value % Modulus));
        public static implicit operator int(ModNumber modNumber) => modNumber._value;
        public static implicit operator BigInteger(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public ModNumber Inverse() => (int) BigInteger.ModPow(_value, Modulus - 2, Modulus);

        public static ModNumber Pow(ModNumber modNumber, int power) => BigInteger.ModPow(modNumber._value, power, Modulus);

        public override string ToString() => _value.ToString();
    }
}
