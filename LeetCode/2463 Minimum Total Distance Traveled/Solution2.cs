using JetBrains.Annotations;

namespace LeetCode._2463_Minimum_Total_Distance_Traveled;

/// <summary>
/// https://leetcode.com/problems/minimum-total-distance-traveled/submissions/838828140/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) => MinimumTotalDistanceImpl(robot, factory);

    private static long MinimumTotalDistanceImpl(IEnumerable<int> robotPositions, IEnumerable<int[]> factoryArrays)
    {
        var robots = robotPositions.Select(position => new Robot(position)).OrderBy(x => x.Position).ToArray();

        var factories = factoryArrays.Select(factoryArray => new Factory(factoryArray[0], factoryArray[1]))
            .OrderBy(x => x.Position).ToArray();

        var factoryIndex = 0;

        foreach (var robot in robots)
        {
            while (factoryIndex < factories.Length && factories[factoryIndex].Position < robot.Position)
            {
                factoryIndex++;
            }

            robot.RightFactoryIndex = factoryIndex;
            robot.LeftFactoryIndex = factoryIndex - 1;

            if (factoryIndex < factories.Length && factories[factoryIndex].Position == robot.Position)
            {
                robot.IsAtFactory = true;
            }
        }

        var queue = new Queue<State>();

        queue.Enqueue(new State(robots, factories));

        var result = long.MaxValue;

        while (queue.Count > 0)
        {
            var state = queue.Dequeue();

            if (state.TotalDistance >= result)
            {
                continue;
            }

            if (state.IsOver())
            {
                result = state.TotalDistance;
                continue;
            }

            var robot = state.AvailableRobots.First();

            MoveToTheNextFactory(robot.RightFactoryIndex, 1);

            if (robot.IsAtFactory && state.IsFactoryAvailable(robot.RightFactoryIndex))
            {
                continue;
            }

            MoveToTheNextFactory(robot.LeftFactoryIndex, -1);
            continue;

            void MoveToTheNextFactory(int factoryIndexStart, int factoryIndexStep)
            {
                for (var i = factoryIndexStart; 0 <= i && i < factories.Length; i += factoryIndexStep)
                {
                    if (!state.IsFactoryAvailable(i))
                    {
                        continue;
                    }

                    var nextState = new State(state);
                    nextState.TotalDistance += Math.Abs(factories[i].Position - robot.Position);
                    nextState.FactoryLimits[i]--;
                    nextState.AvailableRobots.Remove(robot);
                    queue.Enqueue(nextState);
                    break;
                }
            }
        }

        return result;
    }

    private class State
    {
        public State(State state)
        {
            TotalDistance = state.TotalDistance;
            Robots = state.Robots;
            Factories = state.Factories;
            FactoryLimits = state.FactoryLimits.ToArray();
            AvailableRobots = state.AvailableRobots.ToHashSet();
        }

        public State(Robot[] robots, Factory[] factories)
        {
            Robots = robots;
            Factories = factories;
            FactoryLimits = factories.Select(f => f.Limit).ToArray();
            AvailableRobots = robots.ToHashSet();
        }

        public bool IsOver() => AvailableRobots.Count == 0;

        public long TotalDistance { get; set; }
        private Robot[] Robots { get; }
        private Factory[] Factories { get; }
        public int[] FactoryLimits { get; }
        public HashSet<Robot> AvailableRobots { get; }

        public bool IsFactoryAvailable(int factoryIndex) => FactoryLimits[factoryIndex] >= 1;
    }

    private class Robot
    {
        public int Position { get; }
        public int LeftFactoryIndex { get; set; }
        public int RightFactoryIndex { get; set; }
        public bool IsAtFactory { get; set; }

        public Robot(int position)
        {
            Position = position;
        }
    }

    private class Factory
    {
        public int Position { get; }
        public int Limit { get; }

        public Factory(int position, int limit)
        {
            Position = position;
            Limit = limit;
        }
    }
}
