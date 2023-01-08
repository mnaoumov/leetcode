using JetBrains.Annotations;

namespace LeetCode._2529_Maximum_Count_of_Positive_Integer_and_Negative_Integer;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-327/submissions/detail/873709687/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumCount(int[] nums)
    {
        var positiveCount = 0;
        var negativeCount = 0;

        foreach (var num in nums)
        {
            switch (num)
            {
                case > 0:
                    positiveCount++;
                    break;
                case < 0:
                    negativeCount++;
                    break;
            }
        }

        return Math.Max(positiveCount, negativeCount);
    }
}
