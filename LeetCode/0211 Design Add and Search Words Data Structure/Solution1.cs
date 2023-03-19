using JetBrains.Annotations;

namespace LeetCode._0211_Design_Add_and_Search_Words_Data_Structure;

/// <summary>
/// https://leetcode.com/submissions/detail/918379884/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IWordDictionary Create()
    {
        return new WordDictionary1();
    }
}
