using JetBrains.Annotations;

namespace LeetCode.Problems._2141_Maximum_Running_Time_of_N_Computers;

[PublicAPI]
public interface ISolution
{
    public long MaxRunTime(int n, int[] batteries);
}
