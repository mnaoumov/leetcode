using JetBrains.Annotations;

namespace LeetCode._1376_Time_Needed_to_Inform_All_Employees;

[PublicAPI]
public interface ISolution
{
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime);
}
