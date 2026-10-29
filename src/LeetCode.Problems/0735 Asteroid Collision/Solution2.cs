namespace LeetCode.Problems._0735_Asteroid_Collision;

/// <summary>
/// https://leetcode.com/submissions/detail/902692709/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();

        foreach (var asteroid in asteroids)
        {
            var shouldAdd = true;

            while (stack.Count != 0 && stack.Peek() > 0 && asteroid < 0)
            {
                var previousAsteroid = stack.Peek();

                if (Math.Abs(asteroid) < previousAsteroid)
                {
                    shouldAdd = false;
                    break;
                }

                stack.Pop();

                if (Math.Abs(asteroid) > previousAsteroid)
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
