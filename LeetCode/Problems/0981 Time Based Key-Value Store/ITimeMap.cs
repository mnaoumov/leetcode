using JetBrains.Annotations;

namespace LeetCode.Problems._0981_Time_Based_Key_Value_Store;

public interface ITimeMap
{
    [UsedImplicitly]
    public void Set(string key, string value, int timestamp);

    [UsedImplicitly]
    public string Get(string key, int timestamp);
}
