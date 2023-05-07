using JetBrains.Annotations;

namespace LeetCode._1964_Find_the_Longest_Valid_Obstacle_Course_at_Each_Position;

/// <summary>
/// https://leetcode.com/submissions/detail/945741635/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
    {
        var n = obstacles.Length;
        var ans = new int[n];
        var sorted = new List<(int height, int index)>();

        for (var i = 0; i < n; i++)
        {
            var height = obstacles[i];

            var low = 0;
            var high = sorted.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (sorted[mid].height > height)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            ans[i] = 1 + sorted.Take(low).Select(entry => ans[entry.index]).Prepend(0).Max();
            sorted.Insert(low, (height, i));
        }

        return ans;
    }
}
