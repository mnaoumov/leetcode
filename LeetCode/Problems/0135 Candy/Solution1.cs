using JetBrains.Annotations;

namespace LeetCode.Problems._0135_Candy;

/// <summary>
/// https://leetcode.com/problems/candy/submissions/839125605/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int Candy(int[] ratings)
    {
        var result = 0;
        var groupLength = 0;
        var lastValue = 0;

        for (var i = 0; i < ratings.Length; i++)
        {
            if (i == 0 || ratings[i] == ratings[i - 1])
            {
                result++;
                groupLength = 1;
                lastValue = 1;
            }
            else
            {
                groupLength++;

                if (ratings[i] > ratings[i - 1])
                {
                    lastValue++;
                }
                else
                {
                    lastValue--;
                }

                result += lastValue;

                if (lastValue >= 1)
                {
                    continue;
                }

                result += groupLength;
                lastValue = 1;
            }
        }

        return result;
    }
}
