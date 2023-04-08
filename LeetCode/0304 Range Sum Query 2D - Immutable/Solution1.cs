using JetBrains.Annotations;

namespace LeetCode._0304_Range_Sum_Query_2D___Immutable;

/// <summary>
/// https://leetcode.com/submissions/detail/929988814/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public INumMatrix Create(int[][] matrix)
    {
        return new NumMatrix1(matrix);
    }
}
