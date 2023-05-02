using JetBrains.Annotations;

namespace LeetCode._0835_Image_Overlap;

/// <summary>
/// https://leetcode.com/submissions/detail/831686189/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LargestOverlap(int[][] img1, int[][] img2)
    {
        var ones1 = GetOneCoordinates(img1);
        var ones2 = GetOneCoordinates(img2);

        if (ones1.Count > ones2.Count)
        {
            (ones1, ones2) = (ones2, ones1);
        }

        var n = img1.Length;

        var result = 0;

        for (var di = -n + 1; di <= n - 1; di++)
        {
            for (var dj = -n + 1; dj <= n - 1; dj++)
            {
                var overlap = 0;
                foreach (var (row1, column1) in ones1)
                {
                    if (ones2.Contains((row1 + di, column1 + dj)))
                    {
                        overlap++;
                    }
                }

                result = Math.Max(result, overlap);
            }
        }

        return result;
    }

    private static HashSet<(int row, int column)> GetOneCoordinates(IReadOnlyList<int[]> img) =>
        GetOneCoordinatesEnumerable(img).ToHashSet();

    private static IEnumerable<(int row, int column)> GetOneCoordinatesEnumerable(IReadOnlyList<int[]> img)
    {
        var n = img.Count;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (img[i][j] == 1)
                {
                    yield return (i, j);
                }
            }
        }
    }
}
