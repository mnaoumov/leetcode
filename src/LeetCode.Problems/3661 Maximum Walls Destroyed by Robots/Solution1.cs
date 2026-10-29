namespace LeetCode.Problems._3661_Maximum_Walls_Destroyed_by_Robots;

/// <summary>
/// https://leetcode.com/problems/maximum-walls-destroyed-by-robots/submissions/1967273968/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxWalls(int[] robots, int[] distance, int[] walls)
    {
        Array.Sort(walls);

        var n = robots.Length;

        var robotObjs = new Robot[n];

        for (var i = 0; i < n; i++)
        {
            robotObjs[i] = new Robot(robots[i], distance[i]);
        }

        robotObjs = robotObjs.OrderBy(r => r.Position).ToArray();

        const int noWallPosition = int.MinValue;

        var dp = new DynamicProgramming<(int index, int previousDestroyedWallPosition), int>((key, getOrCalculate) =>
        {
            var (index, previousDestroyedWallPosition) = key;

            if (index == n)
            {
                return 0;
            }

            var robot = robotObjs[index];

            var robotIndex = walls.BinarySearch(robot.Position);
            var maxLeftWallIndex = robotIndex >= 0 ? robotIndex : ~robotIndex - 1;
            var minRightWallIndex = robotIndex >= 0 ? robotIndex : ~robotIndex;

            var previousRobot = index > 0 ? robotObjs[index - 1] : new Robot(int.MinValue, 0);
            var nextRobot = index + 1 < n ? robotObjs[index + 1] : new Robot(int.MaxValue, 0);

            var minLeftShootPosition = new[]
            {
                robot.Position - robot.MaxBulletDistance,
                previousDestroyedWallPosition + 1,
                previousRobot.Position + 1
            }.Max();

            var minLeftWallIndex = walls.BinarySearch(minLeftShootPosition);

            if (minLeftWallIndex < 0)
            {
                minLeftWallIndex = ~minLeftWallIndex;
            }

            var ans = 0;

            if (minLeftWallIndex <= maxLeftWallIndex)
            {
                ans = Math.Max(ans,
                    maxLeftWallIndex - minLeftWallIndex + 1 + getOrCalculate((index + 1, noWallPosition)));
            }

            var maxRightShootPosition = new[]
            {
                robot.Position + robot.MaxBulletDistance,
                nextRobot.Position - 1
            }.Min();

            var maxRightWallIndex = walls.BinarySearch(maxRightShootPosition);

            if (maxLeftWallIndex < 0)
            {
                maxRightWallIndex = ~maxRightWallIndex - 1;
            }

            if (minRightWallIndex <= maxRightWallIndex)
            {
                ans = Math.Max(ans,
                    maxRightWallIndex - minRightWallIndex + 1 + getOrCalculate((index + 1, walls[maxRightWallIndex])));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, noWallPosition));
    }

    private sealed record Robot(int Position, int MaxBulletDistance);

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
