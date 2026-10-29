namespace LeetCode.Problems._2426_Number_of_Pairs_Satisfying_Inequality;

/// <summary>
/// https://leetcode.com/submissions/detail/902496822/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long NumberOfPairs(int[] nums1, int[] nums2, int diff)
    {
        var n = nums1.Length;

        var diffs = new SortedSet<int>();

        var result = 0L;

        for (var i = 0; i < n; i++)
        {
            var currentDiff = nums1[i] - nums2[i];
            result += diffs.GetViewBetween(int.MinValue, currentDiff + diff).Count;
            diffs.Add(currentDiff);
        }

        return result;
    }
}
