namespace LeetCode.Problems._1964_Find_the_Longest_Valid_Obstacle_Course_at_Each_Position;

/// <summary>
/// https://leetcode.com/submissions/detail/945744982/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
    {
        var n = obstacles.Length;

        var minHeights = Enumerable.Repeat(int.MaxValue, n).ToArray();
        minHeights[0] = 0;

        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            var height = obstacles[i];

            var low = 0;
            var high = n - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (minHeights[mid] > height)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            ans[i] = low;
            minHeights[low] = Math.Min(minHeights[low], height);
        }

        return ans;
    }
}
