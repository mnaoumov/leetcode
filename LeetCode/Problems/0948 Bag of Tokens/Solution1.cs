using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0948_Bag_of_Tokens;

/// <summary>
/// https://leetcode.com/submissions/detail/1193093531/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int BagOfTokensScore(int[] tokens, int power)
    {
        Array.Sort(tokens);
        var minIndex = 0;
        var maxIndex = tokens.Length - 1;

        var score = 0;
        var ans = 0;

        while (minIndex <= maxIndex)
        {
            if (tokens[minIndex] <= power)
            {
                score++;
                ans = Math.Max(ans, score);
                minIndex++;
            }
            else
            {
                if (score > 0)
                {
                    score--;
                    power += tokens[maxIndex];
                }

                maxIndex--;
            }
        }

        return ans;
    }
}
