namespace LeetCode.Problems._0119_Pascal_s_Triangle_II;

/// <summary>
/// https://leetcode.com/submissions/detail/835127632/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> GetRow(int rowIndex)
    {
        var row = new[] { 1 };

        for (var i = 1; i <= rowIndex; i++)
        {
            var previousRow = row;
            row = new int[i + 1];
            row[0] = row[^1] = 1;

            for (var j = 1; j < i; j++)
            {
                row[j] = previousRow[j - 1] + previousRow[j];
            }
        }

        return row;
    }
}
