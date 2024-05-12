using JetBrains.Annotations;

namespace LeetCode.Problems._0948_Bag_of_Tokens;

/// <summary>
/// https://leetcode.com/submissions/detail/1193094746/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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
                power -= tokens[minIndex];
                ans = Math.Max(ans, score);
                minIndex++;
            }
            else if (score > 0)
            {
                score--;
                power += tokens[maxIndex];
                maxIndex--;
            }
            else
            {
                break;
            }
        }

        return ans;
    }
}
