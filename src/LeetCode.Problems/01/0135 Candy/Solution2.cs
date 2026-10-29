namespace LeetCode.Problems._0135_Candy;

/// <summary>
/// https://leetcode.com/problems/candy/submissions/839145676/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int Candy(int[] ratings)
    {
        var increasingGroupLengths = new List<int>();

        var lastRating = int.MaxValue;

        foreach (var rating in ratings)
        {
            if (rating <= lastRating)
            {
                increasingGroupLengths.Add(1);
                lastRating = 1;
            }
            else
            {
                increasingGroupLengths[^1]++;
                lastRating = increasingGroupLengths[^1];
            }
        }

        var result = 0;

        var lastMin = 0;

        foreach (var groupLength in increasingGroupLengths.Reverse<int>())
        {
            var shift = Math.Max(0, lastMin + 1 - groupLength);

            result += groupLength * (groupLength + 1) / 2 + shift * groupLength;
            lastMin = shift + 1;
        }

        return result;
    }
}
