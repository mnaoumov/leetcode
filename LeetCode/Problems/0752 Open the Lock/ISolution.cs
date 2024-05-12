using JetBrains.Annotations;

namespace LeetCode._0752_Open_the_Lock;

[PublicAPI]
public interface ISolution
{
    public int OpenLock(string[] deadends, string target);
}
