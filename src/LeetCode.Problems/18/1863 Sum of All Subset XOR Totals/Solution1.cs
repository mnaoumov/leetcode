namespace LeetCode.Problems._1863_Sum_of_All_Subset_XOR_Totals;

/// <summary>
/// https://leetcode.com/submissions/detail/1262660280/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SubsetXORSum(int[] nums)
    {
        return Sum(0, 0);

        int Sum(int index, int xor) =>
            index == nums.Length ? xor : Sum(index + 1, xor) + Sum(index + 1, xor ^ nums[index]);
    }
}
