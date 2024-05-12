using JetBrains.Annotations;

namespace LeetCode._1496_Path_Crossing;

/// <summary>
/// https://leetcode.com/submissions/detail/898943771/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPathCrossing(string path)
    {
        var points = new HashSet<(int x, int y)>();

        var point = (x: 0, y: 0);
        points.Add(point);

        foreach (var move in path)
        {
            point = move switch
            {
                'N' => (point.x, point.y - 1),
                'S' => (point.x, point.y + 1),
                'E' => (point.x + 1, point.y),
                'W' => (point.x - 1, point.y),
                _ => throw new ArgumentOutOfRangeException(nameof(path))
            };

            if (!points.Add(point))
            {
                return true;
            }
        }

        return false;
    }
}
