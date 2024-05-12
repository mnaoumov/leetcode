using JetBrains.Annotations;

namespace LeetCode.Problems._0400_Nth_Digit;

/// <summary>
/// https://leetcode.com/submissions/detail/925485707/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int FindNthDigit(int n)
    {
        var digitsCount = 1;
        var groupSize = 9;
        var groupMin = 1;


        while (n > groupSize * digitsCount)
        {
            n -= groupSize * digitsCount;
            digitsCount++;
            groupSize *= 10;
            groupMin *= 10;
        }

        var numIndex = (n + digitsCount - 1) / digitsCount;
        var digitIndex = n - (numIndex - 1) * digitsCount;
        var num = groupMin - 1 + numIndex;

        for (var i = digitsCount; i > digitIndex; i++)
        {
            num /= 10;
        }

        return num % 10;
    }
}
