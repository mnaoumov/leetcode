using JetBrains.Annotations;

namespace LeetCode.Problems._0163_Missing_Ranges;

/// <summary>
/// https://leetcode.com/submissions/detail/871317089/
/// https://leetcode.com/submissions/detail/972352320/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
    {
        var result = new List<IList<int>>();

        var rangeStart = lower;

        foreach (var num in nums)
        {
            var rangeEnd = num - 1;
            ProcessRange(rangeStart, rangeEnd);
            rangeStart = num + 1;
        }

        ProcessRange(rangeStart, upper);

        return result;

        void ProcessRange(int start, int end)
        {
            if (end >= start)
            {
                result.Add(new[] { start, end });
            }
        }
    }
}
