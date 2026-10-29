namespace LeetCode.Problems._0635_Design_Log_Storage_System;

[PublicAPI]
public interface ILogSystem
{
    void Put(int id, string timestamp);
#pragma warning disable CA1716
    IList<int> Retrieve(string start, string end, string granularity);
#pragma warning restore CA1716
}
