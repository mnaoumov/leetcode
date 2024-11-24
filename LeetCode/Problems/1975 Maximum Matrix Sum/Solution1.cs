namespace LeetCode.Problems._1975_Maximum_Matrix_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/1461203405/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxMatrixSum(int[][] matrix)
    {
        var parityPerRows = matrix.Select(row => row.Count(value => value < 0) % 2 == 0).ToArray();
        var canMakeAllPositive = parityPerRows.Count(value => !value) % 2 == 0;

        var ans = matrix.Select(row => row.Select(value => 0L + Math.Abs(value)).Sum()).Sum();

        if (canMakeAllPositive)
        {
            return ans;
        }

        var min = matrix.Select(row => row.Select(Math.Abs).Min()).Min();
        ans -= 2 * min;
        return ans;
    }
}
