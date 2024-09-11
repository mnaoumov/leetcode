using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0556_Next_Greater_Element_III;

/// <summary>
/// https://leetcode.com/submissions/detail/935614907/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
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

            var lastDigit = ansDigits[^1];

            for (var j = m - 1; j >= i + 2; j--)
            {
                ansDigits[j] = ansDigits[i + m - j];
            }

            ansDigits[i + 1] = ansDigits[i];
            ansDigits[i] = lastDigit;

            var ans = 0L;

            for (var j = 0; j < m; j++)
            {
                ans = ans * 10 + ansDigits[j];
            }

            return ans <= int.MaxValue ? (int) ans : -1;
        }

        return -1;
    }
}
