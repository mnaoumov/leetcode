using JetBrains.Annotations;

namespace LeetCode._0835_Image_Overlap;

/// <summary>
/// https://leetcode.com/submissions/detail/831690946/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LargestOverlap(int[][] img1, int[][] img2)
    {
        var ones1 = GetOneCoordinates(img1);
        var ones2 = GetOneCoordinates(img2);

        var maxPossibleResult = Math.Min(ones1.Count, ones2.Count);

        if (maxPossibleResult == 0)
        {
            return 0;
        }

        var result = 0;

        var deltaCounts = new Dictionary<(int di, int dj), int>();

        foreach (var (row1, column1) in ones1)
        {
            foreach (var (row2, column2) in ones2)
            {
                var key = (row2 - row1, column2 - column1);

                deltaCounts.TryAdd(key, 0);

                deltaCounts[key]++;
                result = Math.Max(result, deltaCounts[key]);

                if (result == maxPossibleResult)
                {
                    return maxPossibleResult;
                }
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