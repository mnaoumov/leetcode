using JetBrains.Annotations;

namespace LeetCode._0981_Time_Based_Key_Value_Store;

[PublicAPI]
public interface ISolution
{
    ITimeMap Create();
}