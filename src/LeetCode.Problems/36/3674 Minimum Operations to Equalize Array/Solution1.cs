namespace LeetCode.Problems._3674_Minimum_Operations_to_Equalize_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-466/problems/minimum-operations-to-equalize-array/submissions/1762059139/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums) => nums.Distinct().Count() == 1 ? 0 : 1;
}
