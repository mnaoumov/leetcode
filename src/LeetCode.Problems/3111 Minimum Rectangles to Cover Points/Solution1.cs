namespace LeetCode.Problems._3111_Minimum_Rectangles_to_Cover_Points;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-128/submissions/detail/1231226947/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinRectanglesToCoverPoints(int[][] points, int w)
    {
        var xs = points.Select(p => p[0]).OrderBy(x => x).ToArray();

        var ans = 0;
        var lastX = int.MinValue;

        foreach (var x in xs)
        {
            if (x <= lastX + w)
            {
                continue;
            }

            lastX = x;
            ans++;
        }

        return ans;
    }
}
