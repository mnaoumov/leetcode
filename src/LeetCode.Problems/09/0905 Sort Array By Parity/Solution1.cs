namespace LeetCode.Problems._0905_Sort_Array_By_Parity;

/// <seealso href="https://leetcode.com/submissions/detail/1061011004/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SortArrayByParity(int[] nums) => nums.OrderBy(num => num % 2).ToArray();
}
