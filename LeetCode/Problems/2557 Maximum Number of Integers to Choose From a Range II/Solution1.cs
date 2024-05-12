using JetBrains.Annotations;

namespace LeetCode.Problems._2557_Maximum_Number_of_Integers_to_Choose_From_a_Range_II;

/// <summary>
/// https://leetcode.com/submissions/detail/891666762/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MaxCount(int[] banned, int n, long maxSum)
    {
        var sum = 0L;

        var count = 0;

        foreach (var num in Enumerable.Range(1, n).Except(banned))
        {
            sum += num;

            if (sum > maxSum)
            {
                break;
            }

            count++;
        }

        return count;
    }
}
