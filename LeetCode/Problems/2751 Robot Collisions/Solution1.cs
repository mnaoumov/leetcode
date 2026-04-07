namespace LeetCode.Problems._2751_Robot_Collisions;

/// <summary>
/// https://leetcode.com/problems/robot-collisions/submissions/1966313478/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        var n = positions.Length;
        var robots = new List<Robot>();

        for (var i = 0; i < n; i++)
        {
            robots.Add(new Robot
            {
                OriginalIndex = i,
                Position = positions[i],
                Health = healths[i],
                Direction = directions[i] == 'L' ? Direction.Left : Direction.Right
            });
        }

        var sortedRobots = new LinkedList<Robot>(robots.OrderBy(x => x.Position));

        var pq = new PriorityQueue<Collision, decimal>();

        for (var leftRobotNode = sortedRobots.First; leftRobotNode != null; leftRobotNode = leftRobotNode.Next)
        {
            AddToQueue(leftRobotNode, leftRobotNode.Next);
        }

        while (pq.Count > 0)
        {
            var collision = pq.Dequeue();

            if (collision.LeftRobotNode.List == null || collision.RightRobotNode.List == null)
            {
                continue;
            }

            switch (collision.LeftRobotNode.Value.Health.CompareTo(collision.RightRobotNode.Value.Health))
            {
                case 0:
                    AddToQueue(collision.LeftRobotNode.Previous, collision.RightRobotNode.Next);
                    sortedRobots.Remove(collision.LeftRobotNode);
                    sortedRobots.Remove(collision.RightRobotNode);
                    break;
                case > 0:
                    AddToQueue(collision.LeftRobotNode, collision.RightRobotNode.Next);
                    collision.LeftRobotNode.Value.Health--;
                    sortedRobots.Remove(collision.RightRobotNode);
                    break;
                case < 0:
                    AddToQueue(collision.LeftRobotNode.Previous, collision.RightRobotNode);
                    collision.RightRobotNode.Value.Health--;
                    sortedRobots.Remove(collision.LeftRobotNode);
                    break;
            }
        }

        return sortedRobots.OrderBy(r => r.OriginalIndex).Select(r => r.Health).ToArray();

        void AddToQueue(LinkedListNode<Robot>? leftRobotNode, LinkedListNode<Robot>? rightRobotNode)
        {
            if (leftRobotNode == null || rightRobotNode == null)
            {
                return;
            }

            var leftRobot = leftRobotNode.Value;
            var rightRobot = rightRobotNode.Value;

            if (leftRobot.Direction != Direction.Right || rightRobot.Direction != Direction.Left)
            {
                return;
            }

            var distance = rightRobot.Position - leftRobot.Position;
            var collisionTime = distance / 2;
            pq.Enqueue(new Collision(leftRobotNode, rightRobotNode), collisionTime);
        }
    }

    private enum Direction
    {
        Left,
        Right
    }

    private sealed class Robot
    {
        public int OriginalIndex { get; init; }
        public int Health { get; set; }
        public decimal Position { get; init; }
        public Direction Direction { get; init; }
    }

    private sealed record Collision(LinkedListNode<Robot> LeftRobotNode, LinkedListNode<Robot> RightRobotNode);
}
