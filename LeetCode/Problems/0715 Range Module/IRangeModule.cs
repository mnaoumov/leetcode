namespace LeetCode.Problems._0715_Range_Module;

[PublicAPI]
public interface IRangeModule
{
    public void AddRange(int left, int right);
    public bool QueryRange(int left, int right);
    public void RemoveRange(int left, int right);
}
