namespace LeetCode.Problems._0211_Design_Add_and_Search_Words_Data_Structure;

[PublicAPI]
public interface IWordDictionary
{
    void AddWord(string word);
    bool Search(string word);
}
