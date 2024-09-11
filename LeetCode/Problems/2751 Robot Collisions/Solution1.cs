using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2751_Robot_Collisions;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        var n = positions.Length;
        var robots = new Robot[n];

        for (var i = 0; i < n; i++)
        {
            robots[i] = new Robot
            {
                Position = positions[i],
                Health = healths[i],
                Direction = directions[i] == 'L' ? Direction.Left : Direction.Right
            };
        }

        robots = robots.OrderBy(x => x.Position).ToArray();

        var index = 0;

        while (true)
        {
            while (index < n)
            {
                if (index + 1 < n && robots[index].Direction == Direction.Right && robots[index + 1].Direction == Direction.Left)
                {
                    break;
                }

                index++;
            }

            if (index == n)
            {
                break;
            }

            var robot = robots[index];
            var nextRobot = robots[index + 1];
            var collapsePosition = (robot.Position + nextRobot.Position) / 2m;

            switch (robot.Health.CompareTo(nextRobot.Health))
                {
                    case 0:
                        break;
                    case > 0:
                        robot.Health--;
                        robot.Position = collapsePosition;
                        break;
                    case < 0:
                        nextRobot.Health--;
                        nextRobot.Position = collapsePosition;
                        break;
                }
        }

        return new List<int>();
    }

    private enum Direction
    {
        Left,
        Right
    }

    private class Robot
    {
        public int Health { get; set; }
        public decimal Position { get; set; }
        public Direction Direction { get; init; }
    }
}
