using JetBrains.Annotations;

namespace LeetCode.Problems._1601_Maximum_Number_of_Achievable_Transfer_Requests;

/// <summary>
/// https://leetcode.com/submissions/detail/984097303/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumRequests(int n, int[][] requests)
    {
        var m = requests.Length;

        var ans = 0;

        for (var requestMask = 1; requestMask < 1 << m; requestMask++)
        {
            var changes = new int[n];
            var takenRequestsCount = 0;

            for (var i = 0; i < m; i++)
            {
                if ((requestMask & 1 << i) == 0)
                {
                    continue;
                }

                var request = requests[i];
                changes[request[0]]--;
                changes[request[1]]++;
                takenRequestsCount++;
            }

            if (changes.All(change => change == 0))
            {
                ans = Math.Max(ans, takenRequestsCount);
            }
        }

        return ans;
    }
}
