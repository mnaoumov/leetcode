using JetBrains.Annotations;

namespace LeetCode._2361_Minimum_Costs_Using_the_Train_Line;

[PublicAPI]
public interface ISolution
{
    public long[] MinimumCosts(int[] regular, int[] express, int expressCost);
}
