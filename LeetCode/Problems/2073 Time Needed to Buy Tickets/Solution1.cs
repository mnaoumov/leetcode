using JetBrains.Annotations;

namespace LeetCode.Problems._2073_Time_Needed_to_Buy_Tickets;

/// <summary>
/// https://leetcode.com/submissions/detail/1227301885/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        var n = tickets.Length;

        var ans = 0;

        while (tickets[k] > 0)
        {
            for (var i = 0; i < n; i++)
            {
                if (tickets[i] > 0)
                {
                    tickets[i]--;
                    ans++;
                }

                if (i == k && tickets[k] == 0)
                {
                    break;
                }
            }
        }

        return ans;
    }
}
