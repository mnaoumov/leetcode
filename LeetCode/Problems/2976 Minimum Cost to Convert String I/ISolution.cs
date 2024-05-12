using JetBrains.Annotations;

namespace LeetCode.Problems._2976_Minimum_Cost_to_Convert_String_I;

[PublicAPI]
public interface ISolution
{
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost);
}
