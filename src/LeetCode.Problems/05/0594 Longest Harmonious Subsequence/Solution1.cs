namespace LeetCode.Problems._0594_Longest_Harmonious_Subsequence;

/// <summary>
/// https://leetcode.com/problems/longest-harmonious-subsequence/submissions/1682051795/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindLHS(int[] nums)
    {
        var counts = nums.GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        var ans = 0;

        foreach (var (min, minCount) in counts)
        {
            if (!counts.TryGetValue(min + 1, out var maxCount))
            {
                continue;
            }

            ans = Math.Max(ans, minCount + maxCount);
        }

        return ans;
    }
}
