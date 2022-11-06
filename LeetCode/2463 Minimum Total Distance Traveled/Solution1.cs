using JetBrains.Annotations;

namespace LeetCode._2463_Minimum_Total_Distance_Traveled;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinimumTotalDistance(IList<int> robot, int[][] factory)
    {
        var sortedRobots = robot.ToList();
        sortedRobots.Sort();
        var directions = new Direction[robot.Count];

        for (var i = 0; i < sortedRobots.Count; i++)
        {
            if (sortedRobots[i] <= factory[0][0])
            {
                directions[i] = Direction.Right;
            }
            else
            {
                break;
            }
        }

        for (var i = sortedRobots.Count - 1; i >= 0; i--)
        {
            if (sortedRobots[i] >= factory[^1][0])
            {
                directions[i] = Direction.Left;
            }
            else
            {
                break;
            }
        }

        var sortedFactories = factory.OrderBy(f => f[0]).ToArray();

        return 0;
    }

    private enum Direction
    {
        Unknown,
        Left,
        Right
    }
}
