namespace LeetCode.Problems._3102_Minimize_Manhattan_Distances;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-391/submissions/detail/1218834857/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumDistance(int[][] points)
    {
        var n = points.Length;

        var minSum = int.MaxValue;
        var maxSum = int.MinValue;
        var minDiff = int.MaxValue;
        var maxDiff = int.MinValue;
        var minSumIndex = -1;
        var maxSumIndex = -1;
        var minDiffIndex = -1;
        var maxDiffIndex = -1;

        for (var i = 0; i < n; i++)
        {
            var point = points[i];
            var x = point[0];
            var y = point[1];
            var sum = x + y;
            var diff = x - y;

            if (sum < minSum)
            {
                minSum = sum;
                minSumIndex = i;
            }

            if (sum > maxSum)
            {
                maxSum = sum;
                maxSumIndex = i;
            }

            if (diff < minDiff)
            {
                minDiff = diff;
                minDiffIndex = i;
            }

            // ReSharper disable once InvertIf
            if (diff > maxDiff)
            {
                maxDiff = diff;
                maxDiffIndex = i;
            }
        }

        var ans = int.MaxValue;

        foreach (var skipIndex in new[] { minSumIndex, maxSumIndex, minDiffIndex, maxDiffIndex}.Distinct())
        {
            minSum = int.MaxValue;
            maxSum = int.MinValue;
            minDiff = int.MaxValue;
            maxDiff = int.MinValue;

            for (var i = 0; i < n; i++)
            {
                if (i == skipIndex)
                {
                    continue;
                }

                var point = points[i];
                var x = point[0];
                var y = point[1];
                var sum = x + y;
                var diff = x - y;

                if (sum < minSum)
                {
                    minSum = sum;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                if (diff < minDiff)
                {
                    minDiff = diff;
                }

                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }
            }

            ans = Math.Min(ans, Math.Max(maxSum - minSum, maxDiff - minDiff));
        }

        return ans;
    }
}
