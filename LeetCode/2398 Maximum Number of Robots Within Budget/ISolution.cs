using JetBrains.Annotations;

namespace LeetCode._2398_Maximum_Number_of_Robots_Within_Budget;

[PublicAPI]
public interface ISolution
{
    public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget);
}
