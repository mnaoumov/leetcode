using JetBrains.Annotations;

namespace LeetCode._0621_Task_Scheduler;

[PublicAPI]
public interface ISolution
{
    public int LeastInterval(char[] tasks, int n);
}