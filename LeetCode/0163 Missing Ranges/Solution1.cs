using JetBrains.Annotations;

namespace LeetCode._0163_Missing_Ranges;

/// <summary>
/// https://leetcode.com/submissions/detail/871317089/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
    {
        var result = new List<string>();

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
            if (start == end)
            {
                result.Add($"{start}");
            }
            else if (end > start)
            {
                result.Add($"{start}->{end}");
            }
        }
    }
}
