using JetBrains.Annotations;

namespace LeetCode.Problems._3180_Maximum_Total_Reward_Using_Operations_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-401/submissions/detail/1282352199/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaxTotalReward(int[] rewardValues)
    {
        var uniqueSorted = rewardValues.Distinct().OrderBy(x => x).ToArray();

        if (uniqueSorted.Length == 1)
        {
            return uniqueSorted[0];
        }

        var ans = uniqueSorted[^1] + uniqueSorted[^2];
        var capacity = uniqueSorted[^1] - uniqueSorted[^2];

        for (var i = uniqueSorted.Length - 3; i >= 0; i--)
        {
            if (uniqueSorted[i] >= capacity)
            {
                continue;
            }

            capacity-= uniqueSorted[i];
            ans += uniqueSorted[i];
        }

        return ans;
    }
}
