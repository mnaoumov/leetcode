using JetBrains.Annotations;

namespace LeetCode.Problems._1514_Path_with_Maximum_Probability;

[PublicAPI]
public interface ISolution
{
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end);
}
