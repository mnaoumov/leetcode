using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2483_Minimum_Penalty_for_a_Shop;

/// <summary>
/// https://leetcode.com/submissions/detail/850319258/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int BestClosingTime(string customers)
    {
        var penaltyIfOpen = 0;
        var penaltyIfClosed = 0;
        int result = 0;
        for (var i = 0; i < customers.Length; i++)
        {
            var currentClosedPenalty = customers[i] == 'Y' ? 1 : 0;

            if (penaltyIfClosed <= penaltyIfOpen)
            {
                penaltyIfClosed += currentClosedPenalty;
            }
            else
            {
                penaltyIfClosed = penaltyIfOpen + currentClosedPenalty;
                result = i;
            }
            penaltyIfOpen += 1 - currentClosedPenalty;
        }

        return penaltyIfOpen < penaltyIfClosed ? customers.Length : result;
    }
}
