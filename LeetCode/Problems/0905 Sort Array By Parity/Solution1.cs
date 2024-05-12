using JetBrains.Annotations;

namespace LeetCode._0905_Sort_Array_By_Parity;

/// <summary>
/// https://leetcode.com/submissions/detail/1061011004/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SortArrayByParity(int[] nums) => nums.OrderBy(num => num % 2).ToArray();
}
