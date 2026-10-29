namespace LeetCode.Problems._0715_Range_Module;

[PublicAPI]
public interface IRangeModule
{
    void AddRange(int left, int right);
    bool QueryRange(int left, int right);
    void RemoveRange(int left, int right);
}
