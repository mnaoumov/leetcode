using JetBrains.Annotations;

namespace LeetCode._0438_Find_All_Anagrams_in_a_String;

[PublicAPI]
public interface ISolution
{
    public IList<int> FindAnagrams(string s, string p);
}
