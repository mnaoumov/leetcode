using JetBrains.Annotations;

namespace LeetCode._0815_Bus_Routes;

[PublicAPI]
public interface ISolution
{
    public int NumBusesToDestination(int[][] routes, int source, int target);
}
