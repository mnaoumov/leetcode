using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1838_Frequency_of_the_Most_Frequent_Element;

/// <summary>
/// https://leetcode.com/submissions/detail/935481447/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxFrequency(int[] nums, int k)
    {
        Array.Sort(nums);

        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var frequency = 0;
            var increasesLeft = k;

            for (var j = i; j >= 0; j--)
            {
                increasesLeft -= nums[i] - nums[j];

                if (increasesLeft >= 0)
                {
                    frequency++;
                }
                else
                {
                    break;
                }
            }

            result = Math.Max(result, frequency);
        }

        return result;
    }
}
