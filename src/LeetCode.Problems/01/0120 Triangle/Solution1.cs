namespace LeetCode.Problems._0120_Triangle;

/// <summary>
/// https://leetcode.com/submissions/detail/835721152/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        var resultRow = triangle[^1].ToArray();

        for (var i = triangle.Count - 2; i >= 0; i--)
        {
            for (var j = 0; j <= i; j++)
            {
                resultRow[j] = triangle[i][j] + Math.Min(resultRow[j], resultRow[j + 1]);
            }
        }

        return resultRow[0];
    }
}
