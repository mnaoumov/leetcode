namespace LeetCode.Problems._1267_Count_Servers_that_Communicate;

/// <summary>
/// https://leetcode.com/problems/count-servers-that-communicate/submissions/1517481050/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountServers(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var columnIndicesPerRow = Enumerable.Range(0, m).Select(_ => new List<int>()).ToArray();
        var rowIndicesPerColumn = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] != 1)
                {
                    continue;
                }

                columnIndicesPerRow[i].Add(j);
                rowIndicesPerColumn[j].Add(i);
            }
        }

        var ans = 0;

        for (var i = 0; i < m; i++)
        {
            var count = columnIndicesPerRow[i].Count;

            switch (count)
            {
                case > 1:
                    ans += count;
                    break;
                case 1:
                {
                    var column = columnIndicesPerRow[i][0];
                    if (rowIndicesPerColumn[column].Count > 1)
                    {
                        ans++;
                    }

                    break;
                }
            }
        }

        return ans;
    }
}
