namespace LeetCode.Problems._1605_Find_Valid_Matrix_Given_Row_and_Column_Sums;

/// <summary>
/// https://leetcode.com/submissions/detail/1326834181/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        rowSum = rowSum.ToArray();
        colSum = colSum.ToArray();
        var m = rowSum.Length;
        var n = colSum.Length;
        const int unknown = int.MaxValue;
        var ans = Enumerable.Range(0, m).Select(_ => Enumerable.Repeat(unknown, n).ToArray()).ToArray();

        while (true)
        {
            var min = rowSum.Concat(colSum).Where(x => x > 0).Prepend(unknown).Min();
            if (min == unknown)
            {
                break;
            }

            var rowIndex = Enumerable.Range(0, m).FirstOrDefault(i => rowSum[i] == min, unknown);

            if (rowIndex != unknown)
            {
                var minPlaced = false;
                for (var j = 0; j < n; j++)
                {
                    if (ans[rowIndex][j] != unknown)
                    {
                        continue;
                    }

                    if (!minPlaced)
                    {
                        ans[rowIndex][j] = min;
                        rowSum[rowIndex] = 0;
                        colSum[j] -= min;
                        minPlaced = true;
                    }
                    else
                    {
                        ans[rowIndex][j] = 0;
                    }
                }
            }
            else
            {
                var columnIndex = Enumerable.Range(0, n).FirstOrDefault(j => colSum[j] == min);
                var minPlaced = false;
                for (var i = 0; i < m; i++)
                {
                    if (ans[i][columnIndex] != unknown)
                    {
                        continue;
                    }

                    if (!minPlaced)
                    {
                        ans[i][columnIndex] = min;
                        colSum[columnIndex] = 0;
                        rowSum[i] -= min;
                        minPlaced = true;
                    }
                    else
                    {
                        ans[i][columnIndex] = 0;
                    }
                }
            }
        }

        return ans;
    }
}
