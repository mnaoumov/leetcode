namespace LeetCode.Problems._1232_Check_If_It_Is_a_Straight_Line;

/// <summary>
/// https://leetcode.com/submissions/detail/925632967/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckStraightLine(int[][] coordinates)
    {
        var n = coordinates.Length;

        var x0 = coordinates[1][0] - coordinates[0][0];
        var y0 = coordinates[1][1] - coordinates[0][1];

        for (var i = 2; i < n; i++)
        {
            var x = coordinates[i][0] - coordinates[0][0];
            var y = coordinates[i][1] - coordinates[0][1];

            if (x0 * y != x * y0)
            {
                return false;
            }
        }

        return true;
    }
}
