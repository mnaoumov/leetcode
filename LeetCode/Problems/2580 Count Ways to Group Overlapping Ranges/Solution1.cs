using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode.Problems._2580_Count_Ways_to_Group_Overlapping_Ranges;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-99/submissions/detail/908926444/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountWays(int[][] ranges)
    {
        var orderedRanges = ranges.OrderBy(range => range[0]).ThenBy(range => range[1]).ToArray();
        var groupsCount = 1;
        var lastRange = orderedRanges[0];

        for (var i = 1; i < orderedRanges.Length; i++)
        {
            var range = orderedRanges[i];

            if (lastRange[1] < range[0])
            {
                groupsCount++;
                lastRange = range;
            }
            else
            {
                lastRange = new[] { lastRange[0], Math.Max(lastRange[1], range[1]) };
            }
        }


        return (int) BigInteger.ModPow(2, groupsCount, 1_000_000_007);
    }
}
