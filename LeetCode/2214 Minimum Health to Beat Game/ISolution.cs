using JetBrains.Annotations;

namespace LeetCode._2214_Minimum_Health_to_Beat_Game;

[PublicAPI]
public interface ISolution
{
    public long MinimumHealth(int[] damage, int armor);
}
