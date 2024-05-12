using System.Text;

using JetBrains.Annotations;

namespace LeetCode._0067_Add_Binary;

/// <summary>
/// https://leetcode.com/submissions/detail/819729320/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private const char BinaryZero = '0';
    private const char BinaryOne = '1';

    public string AddBinary(string a, string b)
    {
        if (a == "0" && b == "0")
        {
            return "0";
        }

        var i = 0;
        var carry = false;
        var sb = new StringBuilder();
        while (i < a.Length || i < b.Length || carry)
        {
            var isDigitOneOfA = IsBinaryOneDigit(a, i);
            var isDigitOneOfB = IsBinaryOneDigit(b, i);
            i++;

            (var isDigitOneResult, carry) = AddBinaryDigit(isDigitOneOfA, isDigitOneOfB);
            sb.Insert(0, isDigitOneResult ? BinaryOne : BinaryZero);
        }

        if (carry)
        {
            sb.Insert(0, BinaryOne);
        }

        return sb.ToString();

        bool IsBinaryOneDigit(string binaryNumberStr, int indexFromEnd)
        {
            if (indexFromEnd >= binaryNumberStr.Length)
            {
                return false;
            }

            return binaryNumberStr[binaryNumberStr.Length - 1 - indexFromEnd] == BinaryOne;
        }

        (bool isDigitOneResult, bool carry) AddBinaryDigit(bool isDigitOneOfA, bool isDigitOneOfB)
        {
            return (isDigitOneOfA, isDigitOneOfB, carry) switch
            {
                (false, false, false) => (false, false),
                (false, false, true) => (true, false),
                (false, true, false) => (true, false),
                (false, true, true) => (false, true),
                (true, false, false) => (true, false),
                (true, false, true) => (false, true),
                (true, true, false) => (false, true),
                (true, true, true) => (true, true)
            };
        }
    }
}
