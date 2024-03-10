using JetBrains.Annotations;

namespace LeetCode._3075_Maximize_Happiness_of_Selected_Children;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-388/submissions/detail/1199070915/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumHappinessSum(int[] happiness, int k)
    {
        happiness = happiness.OrderByDescending(x => x).ToArray();
        var ans = 0L;

        for (var i = 0; i < k; i++)
        {
            var diff = happiness[i] - i;

            if (diff <= 0)
            {
                break;
            }

            ans += diff;
        }

        return ans;
    }
}
