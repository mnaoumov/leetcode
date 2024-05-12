using JetBrains.Annotations;

namespace LeetCode.Problems._1230_Toss_Strange_Coins;

[PublicAPI]
public interface ISolution
{
    public double ProbabilityOfHeads(double[] prob, int target);
}
