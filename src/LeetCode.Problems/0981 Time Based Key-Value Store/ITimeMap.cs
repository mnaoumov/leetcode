namespace LeetCode.Problems._0981_Time_Based_Key_Value_Store;

public interface ITimeMap
{
    [UsedImplicitly]
    void Set(string key, string value, int timestamp);

    [UsedImplicitly]
    string Get(string key, int timestamp);
}
