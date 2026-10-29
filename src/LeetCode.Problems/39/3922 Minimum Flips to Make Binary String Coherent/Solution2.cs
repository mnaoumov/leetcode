namespace LeetCode.Problems._1018202_Minimum_Flips_to_Make_Binary_String_Coherent;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-182/problems/minimum-flips-to-make-binary-string-coherent/submissions/1998955723/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MinFlips(string s)
    {
        var n = s.Length;

        var hasZero = false;
        var onesAfterZeroCount = 0;
        var isCoherent = true;

        for (var i = 0; i < n; i++)
        {
            if (s[i] == '0')
            {
                hasZero = true;
            }
            else if (hasZero)
            {
                onesAfterZeroCount++;

                if (onesAfterZeroCount != 2)
                {
                    continue;
                }

                isCoherent = false;
                break;
            }
        }

        if (isCoherent)
        {
            hasZero = false;
            var onesBeforeZeroCount = 0;

            for (var i = n - 1; i >= 0; i--)
            {
                if (s[i] == '0')
                {
                    hasZero = true;
                }
                else if (hasZero)
                {
                    onesBeforeZeroCount++;

                    if (onesBeforeZeroCount != 2)
                    {
                        continue;
                    }

                    isCoherent = false;
                    break;
                }
            }
        }

        if (isCoherent)
        {
            return 0;
        }

        var zeroCount = s.Count(digit => digit == '0');
        var oneCount = n - zeroCount;

        return Math.Min(zeroCount, Math.Max(0, oneCount - 1));
    }
}
