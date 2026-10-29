namespace LeetCode.Problems._2094_Finding_3_Digit_Even_Numbers;

/// <summary>
/// https://leetcode.com/problems/finding-3-digit-even-numbers/submissions/1631545367/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] FindEvenNumbers(int[] digits)
    {
        var n = digits.Length;

        var nums = new SortedSet<int>();

        for (var i = 0; i < n; i++)
        {
            if (digits[i] == 0)
            {
                continue;
            }

            for (var j = 0; j < n; j++)
            {
                if (j == i)
                {
                    continue;
                }

                for (var k = 0; k < n; k++)
                {
                    if (k == i || k == j)
                    {
                        continue;
                    }

                    if (digits[k] % 2 != 0)
                    {
                        continue;
                    }

                    var num = digits[i] * 100 + digits[j] * 10 + digits[k];
                    nums.Add(num);
                }
            }
        }

        return nums.ToArray();
    }
}
