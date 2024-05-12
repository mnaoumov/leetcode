using JetBrains.Annotations;

namespace LeetCode.Problems._0735_Asteroid_Collision;

/// <summary>
/// https://leetcode.com/submissions/detail/902691636/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();

        foreach (var asteroid in asteroids)
        {
            var shouldAdd = true;

            while (stack.Count != 0 && stack.Peek() * asteroid <= 0)
            {
                var previousAsteroid = stack.Peek();

                if (Math.Abs(asteroid) < Math.Abs(previousAsteroid))
                {
                    shouldAdd = false;
                    break;
                }

                stack.Pop();

                if (Math.Abs(asteroid) > Math.Abs(previousAsteroid))
                {
                    continue;
                }

                shouldAdd = false;
                break;
            }

            if (shouldAdd)
            {
                stack.Push(asteroid);
            }
        }

        return stack.Reverse().ToArray();
    }
}
