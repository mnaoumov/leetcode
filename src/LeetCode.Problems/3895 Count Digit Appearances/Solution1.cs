namespace LeetCode.Problems._3895_Count_Digit_Appearances;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-180/problems/count-digit-appearances/submissions/1975422635/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountDigitOccurrences(int[] nums, int digit) => nums.Select(num => CountDigitOccurrences(num, digit)).Sum();

    private static int CountDigitOccurrences(int num, int digit)
    {
        var ans = 0;
        const int decimalBase = 10;

        while (num > 0)
        {
            var lastDigit = num % decimalBase;

            if (lastDigit == digit)
            {
                ans++;
            }

            num /= decimalBase;
        }

        return ans;
    }
}
