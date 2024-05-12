using JetBrains.Annotations;

namespace LeetCode._1235_Maximum_Profit_in_Job_Scheduling;

[PublicAPI]
public interface ISolution
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit);
}
