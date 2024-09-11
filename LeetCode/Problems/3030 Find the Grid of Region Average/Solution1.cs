namespace LeetCode.Problems._3030_Find_the_Grid_of_Region_Average;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-383/submissions/detail/1165429051/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] ResultGrid(int[][] image, int threshold)
    {
        var m = image.Length;
        var n = image[0].Length;
        var result = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();
        var deltas = new (int dRow, int dColumn)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
        var sumCounts = new (int sum, int count)[m, n];

        for (var row = 0; row < m - 2; row++)
        {
            for (var column = 0; column < n - 2; column++)
            {
                if (!IsLeftTopCornerOfTheRegion(row, column))
                {
                    continue;
                }

                var avg = GetAverageRegionIntensity(row, column);
                SetAverageRegionIntensity(row, column, avg);
            }
        }

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                var (sum, count) = sumCounts[row, column];
                result[row][column] = count == 0 ? image[row][column] : sum / count;
            }
        }

        return result;

        bool IsLeftTopCornerOfTheRegion(int topRow, int leftColumn)
        {
            for (var row = topRow; row < topRow + 3; row++)
            {
                for (var column = leftColumn; column < leftColumn + 3; column++)
                {
                    foreach (var (dRow, dColumn) in deltas)
                    {
                        var nextRow = row + dRow;
                        var nextColumn = column + dColumn;

                        if (nextRow < topRow || nextRow >= topRow + 3 || nextColumn < leftColumn || nextColumn >= leftColumn + 3)
                        {
                            continue;
                        }

                        if (Math.Abs(image[nextRow][nextColumn] - image[row][column]) > threshold)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        int GetAverageRegionIntensity(int topRow, int leftColumn)
        {
            var sum = 0;

            for (var x = topRow; x < topRow + 3; x++)
            {
                for (var y = leftColumn; y < leftColumn + 3; y++)
                {
                    sum += image[x][y];
                }
            }

            return sum / 9;
        }

        void SetAverageRegionIntensity(int topRow, int leftColumn, int value)
        {
            for (var x = topRow; x < topRow + 3; x++)
            {
                for (var y = leftColumn; y < leftColumn + 3; y++)
                {
                    var (sum, count) = sumCounts[x, y];
                    sumCounts[x, y] = (sum + value, count + 1);
                }
            }
        }
    }
}
