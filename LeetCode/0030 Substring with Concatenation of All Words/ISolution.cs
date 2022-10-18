using JetBrains.Annotations;

namespace LeetCode._0030_Substring_with_Concatenation_of_All_Words;

[PublicAPI]
public interface ISolution
{
    public IList<int> FindSubstring(string s, string[] words);
}