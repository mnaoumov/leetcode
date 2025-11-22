namespace LeetCode.Problems._3751_Total_Waviness_of_Numbers_in_Range_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-170/problems/total-waviness-of-numbers-in-range-i/submissions/1836833593/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TotalWaviness(int num1, int num2)
    {
        var ans = 0;
        var digits = new List<int>();

        var temp = num1;

        while (temp > 0)
        {
            var digit = temp % 10;
            temp /= 10;
            digits.Insert(0, digit);
        }

        for (var num = num1; num <= num2; num++)
        {
            var m = digits.Count;

            for (var i = 1; i < m - 1; i++)
            {
                if (digits[i] < digits[i - 1] && digits[i] < digits[i + 1] || digits[i] > digits[i - 1] && digits[i] > digits[i + 1])
                {
                    ans++;
                }
            }

            var carry = true;
            for (var i = m - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i]++;
                    carry = false;
                    break;
                }
            }

            if (carry)
            {
                digits.Insert(0, 1);
            }
        }

        return ans;
    }
}
