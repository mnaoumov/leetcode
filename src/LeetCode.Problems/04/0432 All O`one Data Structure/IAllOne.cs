namespace LeetCode.Problems._0432_All_O_one_Data_Structure;

[PublicAPI]
public interface IAllOne
{
    void Inc(string key);
    void Dec(string key);
    string GetMaxKey();
    string GetMinKey();
}
