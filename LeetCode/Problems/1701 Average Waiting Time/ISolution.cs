using JetBrains.Annotations;

namespace LeetCode.Problems._1701_Average_Waiting_Time;

[PublicAPI]
public interface ISolution
{
    public double AverageWaitingTime(int[][] customers);
}
