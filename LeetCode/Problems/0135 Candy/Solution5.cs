using JetBrains.Annotations;

namespace LeetCode.Problems._0135_Candy;

/// <summary>
/// https://leetcode.com/problems/candy/submissions/839174722/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
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
            var groupMaxValue = (index == ratings.Length || ratings[index - 1] != ratings[index]) &&
                                groupLength < lastMin + 1
                ? lastMin + 1
                : groupLength;

            result += groupLength * (groupLength - 1) / 2 + groupMaxValue;
            lastMin = groupLength == 1 ? groupMaxValue : 1;
            index -= groupLength;
        }

        return result;
    }
}
