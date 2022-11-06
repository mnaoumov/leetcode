using JetBrains.Annotations;

namespace LeetCode._2462_Total_Cost_to_Hire_K_Workers;

[PublicAPI]
public interface ISolution
{
    public long TotalCost(int[] costs, int k, int candidates);
}
