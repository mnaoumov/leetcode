using JetBrains.Annotations;

namespace LeetCode._0049_Group_Anagrams;

[PublicAPI]
public interface ISolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs);
}