namespace LeetCode.Problems._2126_Destroying_Asteroids;

/// <summary>
/// https://leetcode.com/submissions/detail/914068203/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        var longMass = (long) mass;

        foreach (var asteroid in asteroids.OrderBy(x => x))
        {
            if (longMass < asteroid)
            {
                return false;
            }

            longMass += asteroid;
        }

        return true;
    }
}
