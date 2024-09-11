using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2731_Movement_of_Robots;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-106/submissions/detail/968186613/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int SumDistance(int[] nums, string s, int d)
    {
        const int modulo = 1_000_000_007;
        var robots = nums.Zip(s, Robot.Create).OrderBy(r => r.Position).ToArray();
        var collisionsTimeQueue = new PriorityQueue<(decimal time, int leftRobotIndex), decimal>();
        collisionsTimeQueue.Enqueue((d, -1), d);

        var n = robots.Length;
        var time = 0m;

        for (var i = 0; i < n - 1; i++)
        {
            ScheduleCollision(i);
        }

        while (time < d)
        {
            var previousDoubleTime = time;
            (time, var leftRobotIndex) = collisionsTimeQueue.Dequeue();

            if (time < d &&
                (robots[leftRobotIndex].Direction != Direction.Right ||
                 robots[leftRobotIndex + 1].Direction != Direction.Left))
            {
                continue;
            }

            for (var i = 0; i < n; i++)
            {
                robots[i].Move(time - previousDoubleTime);

                if (i == 0)
                {
                    continue;
                }

                if (robots[i - 1].Position >= robots[i].Position)
                {
                    robots[i - 1].ChangeDirection();
                    robots[i].ChangeDirection();

                    if (i >= 2)
                    {
                        ScheduleCollision(i - 2);
                    }
                }

                ScheduleCollision(i - 1);
            }
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                ans = (int) ((ans + robots[j].Position - robots[i].Position) % modulo);
            }
        }

        return ans;

        void ScheduleCollision(int i)
        {
            if (robots[i].Direction != Direction.Right || robots[i + 1].Direction != Direction.Left)
            {
                return;
            }

            var distance = robots[i + 1].Position - robots[i].Position;
            var collisionTime = time + distance / 2m;

            if (collisionTime >= d)
            {
                return;
            }

            collisionsTimeQueue.Enqueue((collisionTime, i), collisionTime);
        }
    }

    private class Robot
    {
        public decimal Position { get; private set; }
        public Direction Direction { get; private set; }

        private Robot(int position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        public static Robot Create(int position, char directionChar) => new(position, ToDirection(directionChar));

        private static Direction ToDirection(char directionChar) =>
            directionChar switch
            {
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new ArgumentOutOfRangeException(nameof(directionChar), directionChar, null)
            };

        public void Move(decimal time) => Position += Delta * time;

        private int Delta => Direction switch
        {
            Direction.Left => -1,
            Direction.Right => 1,
            _ => throw new ArgumentOutOfRangeException()
        };

        public void ChangeDirection()
        {
            Direction = Direction switch
            {
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    private enum Direction
    {
        Left,
        Right
    }
}
