// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedVariable
// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Global

using System.Globalization;

namespace LeetCode.Templates;

public static class ModNumberTemplate
{
    public readonly record struct ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(long value) => _value = (int) ((value % Modulo + Modulo) % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new((long) modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new((long) modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new((long) modNumber1._value * modNumber2._value);

        public static ModNumber operator /(ModNumber modNumber1, ModNumber modNumber2)
        {
            if (modNumber2._value == 0)
            {
                throw new DivideByZeroException();
            }

            var inverse = Pow(modNumber2, Modulo - 2);
            return modNumber1 * inverse;
        }

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(0, (current, number) => current + number);

        public static ModNumber Pow(ModNumber value, long exponent)
        {
            ModNumber result = 1;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                {
                    result *= value;
                }

                value *= value;
                exponent >>= 1;
            }

            return result;
        }

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
