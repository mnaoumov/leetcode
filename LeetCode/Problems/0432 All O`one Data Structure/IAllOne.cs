namespace LeetCode.Problems._0432_All_O_one_Data_Structure;

[PublicAPI]
public interface IAllOne
{
    public void Inc(string key);
    public void Dec(string key);
    public string GetMaxKey();
    public string GetMinKey();
}
