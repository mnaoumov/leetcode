using JetBrains.Annotations;

namespace LeetCode._0556_Next_Greater_Element_III;

/// <summary>
/// https://leetcode.com/submissions/detail/935621179/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int NextGreaterElement(int n)
    {
        var ansDigits = new List<int>();

        while (n > 0)
        {
            var digit = n % 10;
            n /= 10;
            ansDigits.Insert(0, digit);
        }

        var m = ansDigits.Count;

        for (var i = m - 2; i >= 0; i--)
        {
            if (ansDigits[i] >= ansDigits[i + 1])
            {
                continue;
            }

            var j = i + 1;

            while (j < m - 1)
            {
                if (ansDigits[j + 1] < ansDigits[i])
                {
                    break;
                }

                j++;
            }

            (ansDigits[i], ansDigits[j]) = (ansDigits[j], ansDigits[i]);

            for (var k = i + 1; k < (i + m + 1) / 2; k++)
            {
                (ansDigits[k], ansDigits[m + i - k]) = (ansDigits[m + i - k], ansDigits[k]);
            }

            var ans = 0L;

            for (var k = 0; k < m; k++)
            {
                ans = ans * 10 + ansDigits[k];
            }

            return ans <= int.MaxValue ? (int) ans : -1;
        }

        return -1;
    }
}
