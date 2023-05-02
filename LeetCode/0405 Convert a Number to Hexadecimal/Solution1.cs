using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0405_Convert_a_Number_to_Hexadecimal;

/// <summary>
/// https://leetcode.com/submissions/detail/926239207/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ToHex(int num)
    {
        // ReSharper disable once StringLiteralTypo
        const string hexDigits = "0123456789abcdef";
        var complementHexDigitMap = new Dictionary<char, char>();

        for (var i = 0; i < hexDigits.Length; i++)
        {
            complementHexDigitMap[hexDigits[i]] = hexDigits[hexDigits.Length - 1 - i];
        }

        switch (num)
        {
            case 0:
                return "0";
            case < 0:
                {
                    var complement = ~num;
                    const int maxHexLength = 8;
                    var complementHex = ToHex(complement).PadLeft(maxHexLength, '0');
                    return string.Concat(complementHex.Select(complementHexDigit => complementHexDigitMap[complementHexDigit]));
                }
            case > 0:
                {
                    var sb = new StringBuilder();

                    while (num > 0)
                    {
                        sb.Insert(0, hexDigits[num % 16]);
                        num /= 16;
                    }

                    return sb.ToString();
                }
        }
    }
}
