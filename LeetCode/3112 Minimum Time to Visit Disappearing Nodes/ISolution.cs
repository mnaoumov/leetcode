using JetBrains.Annotations;

namespace LeetCode._3112_Minimum_Time_to_Visit_Disappearing_Nodes;

[PublicAPI]
public interface ISolution
{
    public int[] MinimumTime(int n, int[][] edges, int[] disappear);
}
