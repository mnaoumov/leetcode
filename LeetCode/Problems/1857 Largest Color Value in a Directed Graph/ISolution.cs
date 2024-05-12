using JetBrains.Annotations;

namespace LeetCode.Problems._1857_Largest_Color_Value_in_a_Directed_Graph;

[PublicAPI]
public interface ISolution
{
    public int LargestPathValue(string colors, int[][] edges);
}
