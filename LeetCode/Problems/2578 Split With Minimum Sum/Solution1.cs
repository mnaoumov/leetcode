using JetBrains.Annotations;

namespace LeetCode._2578_Split_With_Minimum_Sum;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-99/submissions/detail/908901803/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SplitNum(int num)
    {
        var digits = new List<int>();

        while (num > 0)
        {
            var digit = num % 10;
            num /= 10;
            digits.Add(digit);
        }

        digits.Sort();

        var num1 = 0;
        var num2 = 0;

        for (var i = 0; i < digits.Count; i++)
        {
            if (i % 2 == 0)
            {
                num1 = num1 * 10 + digits[i];
            }
            else
            {
                num2 = num2 * 10 + digits[i];
            }
        }

        return num1 + num2;
    }
}
