using JetBrains.Annotations;

namespace LeetCode.Problems._1334_Find_the_City_With_the_Smallest_Number_of_Neighbors_at_a_Threshold_Distance;

[PublicAPI]
public interface ISolution
{
    public int FindTheCity(int n, int[][] edges, int distanceThreshold);
}
