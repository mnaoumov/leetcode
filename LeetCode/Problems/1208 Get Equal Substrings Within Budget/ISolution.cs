using JetBrains.Annotations;

namespace LeetCode.Problems._1208_Get_Equal_Substrings_Within_Budget;

[PublicAPI]
public interface ISolution
{
    public int EqualSubstring(string s, string t, int maxCost);
}
