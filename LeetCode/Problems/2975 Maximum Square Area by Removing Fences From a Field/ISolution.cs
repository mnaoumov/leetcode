using JetBrains.Annotations;

namespace LeetCode.Problems._2975_Maximum_Square_Area_by_Removing_Fences_From_a_Field;

[PublicAPI]
public interface ISolution
{
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences);
}
