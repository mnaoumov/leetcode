namespace LeetCode.Problems._3684_Maximize_Sum_of_At_Most_K_Distinct_Elements;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-467/problems/maximize-sum-of-at-most-k-distinct-elements/submissions/1769963586/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MaxKDistinct(int[] nums, int k) => nums.Distinct().OrderByDescending(num=>num).Take(k).ToArray();
}
