namespace LeetCode.Problems._3661_Maximum_Walls_Destroyed_by_Robots;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int MaxWalls(int[] robots, int[] distance, int[] walls)
    {
        var robotObjs = robots.Zip(distance, (position, distanceValue) => new Robot(position, distanceValue))
            .OrderBy(r => r.Position)
            .ToArray();
        var wallsSet = new SortedSet<int>(walls);

        var destroyedWalls = new HashSet<int>();

        var n = robotObjs.Length;

        for (var i = 0; i < n; i++)
        {
            var robot = robotObjs[i];
            var previousRobot = i > 0 ? robotObjs[i - 1] : new Robot(int.MinValue, 0);
            var nextRobot = i < n - 1 ? robotObjs[i + 1] : new Robot(int.MaxValue, 0);

            var leftBound = Math.Max(robot.Position - robot.Distance, previousRobot.Position + 1);
            var rightBound = Math.Min(robot.Position + robot.Distance, nextRobot.Position - 1);

            var wallsToTheLeft = wallsSet.GetViewBetween(leftBound, robot.Position);
            var wallsToTheRight = wallsSet.GetViewBetween(robot.Position, rightBound);
        }

        return destroyedWalls.Count;
    }

    private record Robot(int Position, int Distance);
}
