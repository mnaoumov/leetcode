using JetBrains.Annotations;

namespace LeetCode._0582_Kill_Process;

[PublicAPI]
public interface ISolution
{
    public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill);
}
