namespace LeetCode.Problems._0874_Walking_Robot_Simulation;

/// <summary>
/// https://leetcode.com/submissions/detail/1379347505/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        var ans = 0;
        var left = (x: -1, y: 0);
        var right = (x: 1, y: 0);
        var down = (x: 0, y: -1);

        var position = (x: 0, y: 0);
        var direction = (x: 0, y: 1);

        var obstaclesByX = new Dictionary<int, SortedSet<int>>();
        var obstaclesByY = new Dictionary<int, SortedSet<int>>();

        foreach (var obstacle in obstacles)
        {
            var x = obstacle[0];
            var y = obstacle[1];
            obstaclesByX.TryAdd(x, new SortedSet<int>());
            obstaclesByY.TryAdd(y, new SortedSet<int>());

            obstaclesByX[x].Add(y);
            obstaclesByY[y].Add(x);
        }

        foreach (var command in commands)
        {
            switch (command)
            {
                case -1:
                    direction = (direction.y, -direction.x);
                    break;
                case -2:
                    direction = (-direction.y, direction.x);
                    break;
                default:
                    var finalPosition = (x: position.x + direction.x * command, y: position.y + direction.y * command);

                    if (direction == left || direction == right)
                    {
                        if (!obstaclesByY.ContainsKey(finalPosition.y))
                        {
                            position = finalPosition;
                        }
                        else
                        {
                            var min = Math.Min(position.x, finalPosition.x);
                            var max = Math.Max(position.x, finalPosition.x);

                            if (obstaclesByY[position.y].Contains(position.x))
                            {
                                if (min == position.x)
                                {
                                    min++;
                                }
                                else if (max == position.x)
                                {
                                    max--;
                                }
                            }

                            var subset = obstaclesByY[position.y].GetViewBetween(min, max);
                            if (subset.Count == 0)
                            {
                                position = finalPosition;
                            }
                            else if (direction == left)
                            {
                                position = finalPosition with { x = subset.Max + 1 };
                            }
                            else
                            {
                                position = finalPosition with { x = subset.Min - 1 };
                            }
                        }
                    }
                    else
                    {
                        if (!obstaclesByX.ContainsKey(finalPosition.x))
                        {
                            position = finalPosition;
                        }
                        else
                        {
                            var min = Math.Min(position.y, finalPosition.y);
                            var max = Math.Max(position.y, finalPosition.y);

                            if (obstaclesByX[position.x].Contains(position.y))
                            {
                                if (min == position.y)
                                {
                                    min++;
                                }
                                else if (max == position.y)
                                {
                                    max--;
                                }
                            }

                            var subset = obstaclesByX[position.x].GetViewBetween(min, max);
                            if (subset.Count == 0)
                            {
                                position = finalPosition;
                            }
                            else if (direction == down)
                            {
                                position = finalPosition with { y = subset.Max + 1 };
                            }
                            else
                            {
                                position = finalPosition with { y = subset.Min - 1 };
                            }
                        }
                    }

                    ans = Math.Max(ans, position.x * position.x + position.y * position.y);
                    break;
            }
        }

        return ans;
    }
}
