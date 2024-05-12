using JetBrains.Annotations;

namespace LeetCode.Problems._1779_Find_Nearest_Point_That_Has_the_Same_X_or_Y_Coordinate;

/// <summary>
/// https://leetcode.com/submissions/detail/924528600/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        var result = -1;
        var minDistance = int.MaxValue;

        for (var i = 0; i < points.Length; i++)
        {
            var point = points[i];

            if (point[0] != x && point[1] != y)
            {
                continue;
            }

            var distance = Math.Abs(point[0] - x) + Math.Abs(point[1] - y);

            if (distance >= minDistance)
            {
                continue;
            }

            minDistance = distance;
            result = i;
        }

        return result;
    }
}
