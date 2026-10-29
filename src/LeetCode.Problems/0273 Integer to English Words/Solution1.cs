using System.Text;

namespace LeetCode.Problems._0273_Integer_to_English_Words;

/// <summary>
/// https://leetcode.com/submissions/detail/1347168842/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string NumberToWords(int num)
    {
        if (num == 0)
        {
            return "Zero";
        }

        var unitNames = new[] { "", "Thousand", "Million", "Billion" };

        var sb = new StringBuilder();

        var unitIndex = 0;

        while (num > 0)
        {
            var unit = num % 1000;
            var unitWords = UnitToWords(unit);

            if (unitWords != "")
            {
                if (unitIndex == 0)
                {
                    sb.Append(unitWords);
                }
                else
                {
                    var str = $"{unitWords} {unitNames[unitIndex]}";
                    if (sb.Length > 0)
                    {
                        str += " ";
                    }

                    sb.Insert(0, str);
                }
            }

            num /= 1000;
            unitIndex++;
        }

        return sb.ToString();
    }

    private static string UnitToWords(int unit)
    {
        if (unit == 0)
        {
            return "";
        }

        var onesNames = new[]
        {
            "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
        };
        var tensNames = new[]
        {
            "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };
        var tenToNineteenNames = new[]
        {
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        var ones = unit % 10;
        var tens = unit / 10 % 10;
        var hundreds = unit / 100;

        var sb = new StringBuilder();

        if (hundreds > 0)
        {
            AppendWord(sb, onesNames[hundreds]);
            AppendWord(sb, "Hundred");
        }

        switch (tens)
        {
            case 1:
                AppendWord(sb, tenToNineteenNames[ones]);
                break;
            case > 1:
                AppendWord(sb, tensNames[tens]);
                break;
        }

        if (tens != 1)
        {
            AppendWord(sb, onesNames[ones]);
        }

        return sb.ToString();
    }

    private static void AppendWord(StringBuilder sb, string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return;
        }

        if (sb.Length > 0)
        {
            sb.Append(" ");
        }

        sb.Append(word);
    }
}
