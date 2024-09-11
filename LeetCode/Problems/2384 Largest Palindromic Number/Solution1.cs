using System.Text;

namespace LeetCode.Problems._2384_Largest_Palindromic_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/914100462/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string LargestPalindromic(string num)
    {
        var result = new StringBuilder();
        var middleOddCountLetter = default(char);
        var hasNonZeroDigits = false;

        foreach (var (digit, count) in num.GroupBy(digit => digit).Select(g => (digit: g.Key, count: g.Count())).OrderByDescending(x => x.digit))
        {
            if (digit == '0' && !hasNonZeroDigits)
            {
                if (middleOddCountLetter == default)
                {
                    middleOddCountLetter = '0';
                }

                break;
            }

            if (count % 2 == 0)
            {
                result.Append(digit, count / 2);
            }
            else
            {
                result.Append(digit, count / 2);

                if (middleOddCountLetter == default)
                {
                    middleOddCountLetter = digit;
                }
            }

            if (!hasNonZeroDigits && count > 1)
            {
                hasNonZeroDigits = true;
            }
        }

        var halfLength = result.Length;

        if (middleOddCountLetter != default)
        {
            result.Append(middleOddCountLetter);
        }

        for (var i = halfLength - 1; i >= 0; i--)
        {
            result.Append(result[i]);
        }

        return result.ToString();
    }
}
