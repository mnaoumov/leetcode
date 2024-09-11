namespace LeetCode.Problems._1292_Maximum_Side_Length_of_a_Square_with_Sum_Less_than_or_Equal_to_Threshold;

/// <summary>
/// https://leetcode.com/submissions/detail/950586782/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxSideLength(int[][] mat, int threshold)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var prefixSums = new int[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                prefixSums[i, j] =
                    (i > 0 ? prefixSums[i - 1, j] : 0)
                    + (j > 0 ? prefixSums[i, j - 1] : 0)
                    - (i > 0 && j > 0 ? prefixSums[i - 1, j - 1] : 0)
                    + mat[i][j];
            }
        }

        var low = 1;
        var high = Math.Min(m, n);

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (HasSquareWithinThreshold(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool HasSquareWithinThreshold(int mid)
        {
            for (var i = 0; i < m - mid; i++)
            {
                for (var j = 0; j < n - mid; j++)
                {
                    var bottom = i + mid - 1;
                    var right = j + mid - 1;
                    var sum =
                        prefixSums[bottom, right]
                        - (i > 0 ? prefixSums[i - 1, right] : 0)
                        - (j > 0 ? prefixSums[bottom, j - 1] : 0)
                        + (i > 0 && j > 0 ? prefixSums[i - 1, j - 1] : 0);

                    if (sum <= threshold)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
