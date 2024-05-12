using JetBrains.Annotations;

namespace LeetCode.Problems._2554_Maximum_Number_of_Integers_to_Choose_From_a_Range_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-97/submissions/detail/891340712/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxCount(int[] banned, int n, int maxSum)
    {
        var sum = 0;
        var result = 0;

        foreach (var num in Enumerable.Range(1, n).Except(banned))
        {
            var nextSum = sum + num;

            if (nextSum > maxSum)
            {
                break;
            }

            result++;
            sum = nextSum;
        }

        return result;
    }
}
