using JetBrains.Annotations;

namespace LeetCode.Problems._0211_Design_Add_and_Search_Words_Data_Structure;

[PublicAPI]
public interface IWordDictionary
{
    public void AddWord(string word);
    public bool Search(string word);
}
