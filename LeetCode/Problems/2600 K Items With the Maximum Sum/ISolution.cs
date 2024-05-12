using JetBrains.Annotations;

namespace LeetCode._2600_K_Items_With_the_Maximum_Sum;

[PublicAPI]
public interface ISolution
{
    public int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k);
}
