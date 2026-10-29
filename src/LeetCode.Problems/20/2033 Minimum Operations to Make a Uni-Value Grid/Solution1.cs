namespace LeetCode.Problems._2033_Minimum_Operations_to_Make_a_Uni_Value_Grid;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/submissions/1587320564/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[][] grid, int x)
    {
        var nums = grid.SelectMany(num => num).OrderBy(num => num).ToArray();
        var p = nums.Length;
        var median = nums[p / 2];
        var ans = 0;

        foreach (var num in nums)
        {
            var diff = Math.Abs(num - median);
            if (diff % x != 0)
            {
                return -1;
            }

            ans += diff / x;
        }

        return ans;
    }
}
