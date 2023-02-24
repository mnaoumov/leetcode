using JetBrains.Annotations;

namespace LeetCode._2426_Number_of_Pairs_Satisfying_Inequality;

/// <summary>
/// https://leetcode.com/submissions/detail/902500598/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long NumberOfPairs(int[] nums1, int[] nums2, int diff)
    {
        var n = nums1.Length;

        var sortedDiffs = new SortedSet<(int diff, int count)>();
        var duplicateDiffCounts = new Dictionary<int, int>();

        var result = 0L;

        for (var i = 0; i < n; i++)
        {
            var currentDiff = nums1[i] - nums2[i];
            result += sortedDiffs.GetViewBetween((int.MinValue, 0), (currentDiff + diff, int.MaxValue)).Count;
            duplicateDiffCounts[currentDiff] = duplicateDiffCounts.GetValueOrDefault(currentDiff) + 1;
            sortedDiffs.Add((currentDiff, duplicateDiffCounts[currentDiff]));
        }

        return result;
    }
}
