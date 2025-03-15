namespace LeetCode.Problems._3483_Unique_3_Digit_Even_Numbers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-152/problems/unique-3-digit-even-numbers/submissions/1574553288/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TotalNumbers(int[] digits)
    {
        var set = new HashSet<int>();

        var n = digits.Length;

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
                    if (k == j || k == i)
                    {
                        continue;
                    }

                    if (digits[k] % 2 != 0)
                    {
                        continue;
                    }

                    var num = 100 * digits[i] + 10 * digits[j] + digits[k];
                    set.Add(num);
                }
            }
        }

        return set.Count;
    }
}
