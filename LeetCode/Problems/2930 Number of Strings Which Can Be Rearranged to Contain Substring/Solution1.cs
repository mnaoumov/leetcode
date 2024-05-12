using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._2930_Number_of_Strings_Which_Can_Be_Rearranged_to_Contain_Substring;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-117/submissions/detail/1096637372/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int StringCount(int n)
    {
        if (n < 4)
        {
            return 0;
        }

        const int lettersCount = 26;

        var allLettersWordsCount = ModNumber.Pow(lettersCount, n);

        var excludeOneLetterCount = ModNumber.Pow(lettersCount - 1, n);
        var oneLetterSingleCount = n * ModNumber.Pow(lettersCount - 1, n - 1);

        // ReSharper disable InlineTemporaryVariable
        var noLCount = excludeOneLetterCount;
        var noECount = excludeOneLetterCount;
        var singleECount = oneLetterSingleCount;
        var noTCount = excludeOneLetterCount;

        var excludeTwoLettersCount = ModNumber.Pow(lettersCount - 2, n);
        var oneLetterSingleExcludeOtherPlaceCount = n * ModNumber.Pow(lettersCount - 2, n - 1);

        var noLeCount = excludeTwoLettersCount;
        var noLtCount = excludeTwoLettersCount;
        var noEtCount = excludeTwoLettersCount;
        var noLSingleECount = oneLetterSingleExcludeOtherPlaceCount;
        var noTSingleECount = oneLetterSingleExcludeOtherPlaceCount;

        var noLetCount = ModNumber.Pow(lettersCount - 3, n);
        var singleENoLeCount = n * ModNumber.Pow(lettersCount - 3, n - 1);
        // ReSharper restore InlineTemporaryVariable

        return allLettersWordsCount
               - noLCount - noECount - singleECount - noTCount
               + noLeCount + noLtCount + noEtCount + noLSingleECount + noTSingleECount
               - noLetCount - singleENoLeCount;
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(value) + Modulo;

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator ModNumber(BigInteger value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;
        public static implicit operator BigInteger(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber Pow(ModNumber modNumber1, ModNumber modNumber2) =>
            BigInteger.ModPow(modNumber1, modNumber2, Modulo);

        public override string ToString() => _value.ToString();
    }
}
