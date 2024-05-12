using JetBrains.Annotations;

namespace LeetCode.Problems._3047_Find_the_Largest_Area_of_Square_Inside_Two_Rectangles;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-386/submissions/detail/1185332779/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long LargestSquareArea(int[][] bottomLeft, int[][] topRight)
    {
        var n = bottomLeft.Length;
        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            var (left1, bottom1, right1, top1) = Coordinate(i);

            for (var j = i + 1; j < n; j++)
            {
                var (left2, bottom2, right2, top2) = Coordinate(j);

                var left = Math.Max(left1, left2);
                var bottom = Math.Max(bottom1, bottom2);
                var right = Math.Min(right1, right2);
                var top = Math.Min(top1, top2);

                if (left >= right || bottom >= top)
                {
                    continue;
                }

                var side = Math.Min(right - left, top - bottom);
                ans = Math.Max(ans, 1L * side * side);
            }
        }

        return ans;

        (int left, int bottom, int right, int top) Coordinate(int i)
        {
            return (bottomLeft[i][0], bottomLeft[i][1], topRight[i][0], topRight[i][1]);
        }
    }
}
