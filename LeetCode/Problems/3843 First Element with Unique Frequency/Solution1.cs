namespace LeetCode.Problems._3843_First_Element_with_Unique_Frequency;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-489/problems/first-element-with-unique-frequency/submissions/1919553786/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FirstUniqueFreq(int[] nums)
    {
        var counts = nums.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var countsOfCounts = counts.Values.GroupBy(count => count).ToDictionary(g => g.Key, g => g.Count());
        var uniqueCounts = countsOfCounts.Where(kvp => kvp.Value == 1).Select(kv => kv.Key).ToHashSet();
        var numsWithUniqueFreq = counts.Where(kvp => uniqueCounts.Contains(kvp.Value)).Select(kv => kv.Key).ToHashSet();
        return nums.FirstOrDefault(num => numsWithUniqueFreq.Contains(num), -1);
    }
}
