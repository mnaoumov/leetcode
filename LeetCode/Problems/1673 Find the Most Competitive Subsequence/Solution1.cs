using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1673_Find_the_Most_Competitive_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/903227395/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] MostCompetitive(int[] nums, int k)
    {
        var list = new List<int>();

        for (var i = 0; i < k; i++)
        {
            list.Add(nums[i]);
        }

        for (var i = k; i < nums.Length; i++)
        {
            list.Add(nums[i]);

            for (var j = 0; j < k; j++)
            {
                if (list[j] <= list[j + 1])
                {
                    continue;
                }

                list.RemoveAt(j);
                break;
            }

            if (list.Count > k)
            {
                list.RemoveAt(k);
            }
        }

        return list.ToArray();
    }
}
