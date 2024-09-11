using System.Text;

namespace LeetCode.Problems._0166_Fraction_to_Recurring_Decimal;

/// <summary>
/// https://leetcode.com/submissions/detail/875884658/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FractionToDecimal(int numerator, int denominator)
    {
        if (numerator == 0)
        {
            return "0";
        }

        var numeratorLong = (long) numerator;
        var denominatorLong = (long) denominator;

        var sign = 1;

        if (numeratorLong < 0)
        {
            sign = -sign;
            numeratorLong = -numeratorLong;
        }

        if (denominatorLong < 0)
        {
            sign = -sign;
            denominatorLong = -denominatorLong;
        }

        var sb = new StringBuilder();

        if (sign == -1)
        {
            sb.Append('-');
        }

        var integerPart = numeratorLong / denominatorLong;
        sb.Append(integerPart);

        numeratorLong %= denominatorLong;

        if (numeratorLong == 0)
        {
            return sb.ToString();
        }

        sb.Append('.');

        var remainderIndexMap = new Dictionary<long, int>();

        while (true)
        {
            remainderIndexMap[numeratorLong] = sb.Length;
            numeratorLong *= 10;
            var digit = numeratorLong / denominatorLong;
            sb.Append(digit);
            numeratorLong %= denominatorLong;

            if (numeratorLong == 0)
            {
                break;
            }

            if (!remainderIndexMap.TryGetValue(numeratorLong, out var index))
            {
                continue;
            }

            sb.Insert(index, '(');
            sb.Append(')');
            break;
        }

        return sb.ToString();
    }
}
