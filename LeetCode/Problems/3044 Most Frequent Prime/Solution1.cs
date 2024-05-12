using JetBrains.Annotations;

namespace LeetCode.Problems._3044_Most_Frequent_Prime;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-385/submissions/detail/1178470346/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MostFrequentPrime(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var directions = new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };
        var counts = new Dictionary<int, int>();
        var primesDict = new Dictionary<int, bool>();

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                foreach (var (dRow, dColumn) in directions)
                {
                    var num = 0;
                    var cell = (row, column);

                    while (0 <= cell.row && cell.row < m && 0 <= cell.column && cell.column < n)
                    {
                        num = 10 * num + mat[cell.row][cell.column];
                        cell = (row: cell.row + dRow, column: cell.column + dColumn);

                        if (num <= 10 || !IsPrime(num))
                        {
                            continue;
                        }

                        counts.TryAdd(num, 0);
                        counts[num]++;
                    }
                }
            }
        }

        if (counts.Count == 0)
        {
            return -1;
        }

        var maxCount = counts.Values.Max();
        return counts.Keys.Where(key => counts[key] == maxCount).Max();

        bool IsPrime(int num)
        {
            if (primesDict.TryGetValue(num, out var isPrime))
            {
                return isPrime;
            }

            if (num == 1)
            {
                return primesDict[num] = false;
            }

            for (var d = 2; d <= (int) Math.Sqrt(num); d++)
            {
                if (num % d == 0)
                {
                    return primesDict[num] = false;
                }
            }

            return primesDict[num] = true;
        }
    }
}
