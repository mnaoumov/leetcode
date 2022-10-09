using System.Text;

namespace LeetCode._0038_Count_and_Say;

/// <summary>
/// https://leetcode.com/submissions/detail/813820267/
/// </summary>
public class Solution1 : ISolution
{
    public string CountAndSay(int n)
    {
        if (n == 1)
        {
            return "1";
        }

        var str = CountAndSay(n - 1);

        var lastDigit = str[0];
        var count = 1;

        var result = new StringBuilder();

        foreach (var digit in str[1..] + '\0')
        {
            if (digit == lastDigit)
            {
                count++;
            }
            else
            {
                result.Append(count);
                result.Append(lastDigit);

                lastDigit = digit;
                count = 1;
            }
        }

        return result.ToString();
    }
}