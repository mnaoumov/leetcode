using JetBrains.Annotations;

namespace LeetCode._0857_Minimum_Cost_to_Hire_K_Workers;

[PublicAPI]
public interface ISolution
{
    public double MincostToHireWorkers(int[] quality, int[] wage, int k);
}
