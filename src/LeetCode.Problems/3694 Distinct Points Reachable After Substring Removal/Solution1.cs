namespace LeetCode.Problems._3694_Distinct_Points_Reachable_After_Substring_Removal;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-166/problems/distinct-points-reachable-after-substring-removal/submissions/1784308895/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DistinctPoints(string s, int k)
    {
        var totalDx = 0;
        var totalDy = 0;
        const char up = 'U';
        const char down = 'D';
        const char left = 'L';
        const char right = 'R';

        var directions = new Dictionary<char, (int dx, int dy)>
        {
            [up] = (0, -1),
            [down] = (0, 1),
            [left] = (-1, 0),
            [right] = (1, 0)
        };


        var totalShifts = new HashSet<(int dx, int dy)>();

        for (var i = 0; i < k; i++)
        {
            var direction = directions[s[i]];
            totalDx += direction.dx;
            totalDy += direction.dy;
        }

        totalShifts.Add((totalDx, totalDy));

        for (var i = k; i < s.Length; i++)
        {
            var direction = directions[s[i]];
            totalDx += direction.dx;
            totalDy += direction.dy;
            var oldDirection = directions[s[i - k]];
            totalDx -= oldDirection.dx;
            totalDy -= oldDirection.dy;
            totalShifts.Add((totalDx, totalDy));
        }

        return totalShifts.Count;
    }
}
