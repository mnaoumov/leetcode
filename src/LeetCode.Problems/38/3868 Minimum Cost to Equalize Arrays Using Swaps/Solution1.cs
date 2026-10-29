namespace LeetCode.Problems._3868_Minimum_Cost_to_Equalize_Arrays_Using_Swaps;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-178/problems/minimum-cost-to-equalize-arrays-using-swaps/submissions/1948069259/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCost(int[] nums1, int[] nums2)
    {
        var counts = nums1.Concat(nums2).GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());

        if (counts.Values.Any(count => count % 2 != 0))
        {
            return -1;
        }

        var counts1 = nums1.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());

        return counts.Select(kvp => Math.Abs(counts1.GetValueOrDefault(kvp.Key) - kvp.Value / 2)).Sum() / 2;
    }
}
