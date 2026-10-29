namespace LeetCode.Problems._2536_Increment_Submatrices_by_One;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-328/submissions/detail/878339876/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        var result = Enumerable.Range(0, n).Select(_ => new int[n]).ToArray();

        foreach (var query in queries)
        {
            var row1 = query[0];
            var col1 = query[1];
            var row2 = query[2];
            var col2 = query[3];

            for (var row = row1; row <= row2; row++)
            {
                for (var col = col1; col <= col2; col++)
                {
                    result[row][col]++;
                }
            }
        }

        return result;
    }
}
