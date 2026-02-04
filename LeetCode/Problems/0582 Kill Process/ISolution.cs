namespace LeetCode.Problems._0582_Kill_Process;

[PublicAPI]
public interface ISolution
{
    IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill);
}
