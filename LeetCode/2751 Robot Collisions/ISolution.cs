using JetBrains.Annotations;

namespace LeetCode._2751_Robot_Collisions;

[PublicAPI]
public interface ISolution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions);
}
