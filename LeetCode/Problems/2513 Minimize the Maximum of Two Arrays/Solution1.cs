using JetBrains.Annotations;

namespace LeetCode._2513_Minimize_the_Maximum_of_Two_Arrays;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-94/submissions/detail/864795988/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimizeSet(int divisor1, int divisor2, int uniqueCnt1, int uniqueCnt2)
    {
        var skippedNumbersToReuseInSecondArrayCount = 0;

        var maxNum = 0;

        for (var i = 0; i < uniqueCnt1; i++)
        {
            maxNum++;

            if (maxNum % divisor1 != 0)
            {
                continue;
            }

            if (maxNum % divisor2 != 0)
            {
                skippedNumbersToReuseInSecondArrayCount++;
            }

            maxNum++;
        }

        for (var i = skippedNumbersToReuseInSecondArrayCount; i < uniqueCnt2; i++)
        {
            maxNum++;

            if (maxNum % divisor2 != 0)
            {
                continue;
            }

            maxNum++;
        }

        return maxNum;
    }
}
