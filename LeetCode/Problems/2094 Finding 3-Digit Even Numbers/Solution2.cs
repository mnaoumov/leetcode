namespace LeetCode.Problems._2094_Finding_3_Digit_Even_Numbers;

/// <summary>
/// https://leetcode.com/problems/finding-3-digit-even-numbers/submissions/1631550325/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] FindEvenNumbers(int[] digits)
    {
        var counts = new int[10];

        foreach (var digit in digits)
        {
            counts[digit]++;
        }

        var ans = new List<int>();

        for (var num = 100; num < 1000; num += 2)
        {
            var numDigits = new[] { num / 100, num / 10 % 10, num % 10 };

            var isValid = true;

            foreach (var digit in numDigits)
            {
                counts[digit]--;
                if (counts[digit] < 0)
                {
                    isValid = false;
                }
            }

            foreach (var digit in numDigits)
            {
                counts[digit]++;
            }

            if (isValid)
            {
                ans.Add(num);
            }
        }

        return ans.ToArray();
    }
}
