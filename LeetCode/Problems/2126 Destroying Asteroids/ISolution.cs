using JetBrains.Annotations;

namespace LeetCode._2126_Destroying_Asteroids;

[PublicAPI]
public interface ISolution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids);
}
