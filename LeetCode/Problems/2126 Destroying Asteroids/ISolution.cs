using JetBrains.Annotations;

namespace LeetCode.Problems._2126_Destroying_Asteroids;

[PublicAPI]
public interface ISolution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids);
}
