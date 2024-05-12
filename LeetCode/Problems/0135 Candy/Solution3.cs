using JetBrains.Annotations;

namespace LeetCode.Problems._0135_Candy;

/// <summary>
/// https://leetcode.com/problems/candy/submissions/839161270/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
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
            }
            else
            {
                increasingGroupLengths[^1]++;
            }

            lastRating = rating;
        }

        var result = 0;

        var lastMin = 0;

        var index = ratings.Length;

        foreach (var groupLength in increasingGroupLengths.Reverse<int>())
        {
            index -= groupLength;

            if (groupLength == 1 && index < ratings.Length - 1 && ratings[index] == ratings[index + 1])
            {
                result++;
                lastMin = 1;
            }
            else
            {
                var shift = Math.Max(0, lastMin + 1 - groupLength);

                result += groupLength * (groupLength + 1) / 2 + shift * groupLength;
                lastMin = shift + 1;
            }
        }

        return result;
    }
}
