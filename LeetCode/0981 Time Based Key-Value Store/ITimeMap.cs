namespace LeetCode._0981_Time_Based_Key_Value_Store;

public interface ITimeMap
{
    public void Set(string key, string value, int timestamp);
    public string Get(string key, int timestamp);
}