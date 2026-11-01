namespace LeetCode.Problems._2126_Destroying_Asteroids;

/// <seealso href="https://leetcode.com/submissions/detail/914067639/"/>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        foreach (var asteroid in asteroids.OrderBy(x => x))
        {
            if (mass < asteroid)
            {
                return false;
            }

            mass += asteroid;
        }

        return true;
    }
}
