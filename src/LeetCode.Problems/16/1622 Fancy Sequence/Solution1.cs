using System.Globalization;
using System.Numerics;

namespace LeetCode.Problems._1622_Fancy_Sequence;

/// <summary>
/// https://leetcode.com/problems/fancy-sequence/submissions/1948485414/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IFancy Create() => new Fancy();

    private sealed class Fancy : IFancy
    {
        private readonly List<ModNumber> _rawNums = new();
        private ModNumber _commonAddendum = 0;
        private ModNumber _commonMultiplier = 1;

        public void Append(int val)
        {
            var rawNum = (val - _commonAddendum) / _commonMultiplier;
            _rawNums.Add(rawNum);
        }
    
        public void AddAll(int inc)
        {
            _commonAddendum += inc;
        }
    
        public void MultAll(int m)
        {
            _commonMultiplier *= m;
            _commonAddendum *= m;
        }
    
        public int GetIndex(int idx)
        {
            if (idx >= _rawNums.Count)
            {
                return -1;
            }

            return _rawNums[idx] * _commonMultiplier + _commonAddendum;
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

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
