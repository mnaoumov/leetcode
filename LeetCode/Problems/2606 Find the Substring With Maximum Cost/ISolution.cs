using JetBrains.Annotations;

namespace LeetCode._2606_Find_the_Substring_With_Maximum_Cost;

[PublicAPI]
public interface ISolution
{
    public int MaximumCostSubstring(string s, string chars, int[] vals);
}
