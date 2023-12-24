using JetBrains.Annotations;

namespace LeetCode._2977_Minimum_Cost_to_Convert_String_II;

[PublicAPI]
public interface ISolution
{
    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost);
}
