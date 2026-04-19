using System.Globalization;
using System.Numerics;

namespace LeetCode.Problems._3897_Maximum_Value_of_Concatenated_Binary_Segments;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-180/problems/maximum-value-of-concatenated-binary-segments/submissions/1975554250/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxValue(int[] nums1, int[] nums0)
    {
        var n = nums0.Length;
        var segments = new Segment[n];

        for (var i = 0; i < n; i++)
        {
            segments[i] = new Segment(nums0[i], nums1[i]);
        }

        segments = segments.OrderBy(segment => segment).ToArray();


        var length = 0;
        ModNumber ans = 0;

        foreach (var segment in segments)
        {
            ans += ModNumber.Pow(2, segment.ZerosCount + length) * (ModNumber.Pow(2, segment.OnesCount) - 1);
            length += segment.OnesCount + segment.ZerosCount;
        }

        return ans;
    }

    private sealed record Segment(int ZerosCount, int OnesCount) : IComparable<Segment>
    {
        public int CompareTo(Segment? other)
        {
            if (this == other)
            {
                return 0;
            }

            if (other is null)
            {
                return 1;
            }

            if (ZerosCount == 0)
            {
                return other.ZerosCount == 0 ? 0 : 1;
            }

            if (other.ZerosCount == 0)
            {
                return -1;
            }

            if (OnesCount < other.OnesCount)
            {
                return -1;
            }

            if (OnesCount > other.OnesCount)
            {
                return 1;
            }

            return other.ZerosCount.CompareTo(ZerosCount);
        }
    }

    private sealed class ModNumber
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

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }

}
