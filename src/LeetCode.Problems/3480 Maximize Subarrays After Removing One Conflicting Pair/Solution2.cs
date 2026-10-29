namespace LeetCode.Problems._3480_Maximize_Subarrays_After_Removing_One_Conflicting_Pair;

/// <summary>
/// https://leetcode.com/problems/maximize-subarrays-after-removing-one-conflicting-pair/submissions/1712675986/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxSubarrays(int n, int[][] conflictingPairs)
    {
        var smallestConflictingGreaterValue = new int[n + 1];
        var secondSmallestConflictingGreaterValue = new int[n + 1];
        Array.Fill(smallestConflictingGreaterValue, n + 1);
        Array.Fill(secondSmallestConflictingGreaterValue, n + 1);

        foreach (var pair in conflictingPairs)
        {
            var a = pair[0];
            var b = pair[1];

            if (a > b)
            {
                (a, b) = (b, a);
            }

            if (smallestConflictingGreaterValue[a] > b)
            {
                (smallestConflictingGreaterValue[a], secondSmallestConflictingGreaterValue[a]) =
                    (b, smallestConflictingGreaterValue[a]);
            }
            else if (secondSmallestConflictingGreaterValue[a] > b)
            {
                secondSmallestConflictingGreaterValue[a] = b;
            }
        }

        var ans = 0L;
        var smallest1 = n;
        var smallest2 = n + 1;

        var additionalSubarraysCountAfterRemoval = new long[n + 1];

        for (var i = n; i >= 1; i--)
        {
            if (smallestConflictingGreaterValue[smallest1] > smallestConflictingGreaterValue[i])
            {
                smallest2 = Math.Min(smallest2, smallestConflictingGreaterValue[smallest1]);
                smallest1 = i;
            }
            else
            {
                smallest2 = Math.Min(smallest2, smallestConflictingGreaterValue[i]);
            }

            ans += smallestConflictingGreaterValue[smallest1] - i;

            additionalSubarraysCountAfterRemoval[smallest1] +=
                Math.Min(smallest2, secondSmallestConflictingGreaterValue[smallest1]) -
                smallestConflictingGreaterValue[smallest1];
        }

        return ans + additionalSubarraysCountAfterRemoval.Max();
    }
}
