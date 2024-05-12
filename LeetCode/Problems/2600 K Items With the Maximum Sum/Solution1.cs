using JetBrains.Annotations;

namespace LeetCode._2600_K_Items_With_the_Maximum_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-338/submissions/detail/922162701/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
    {
        var result = 0;

        var takeCount = Math.Min(numOnes, k);
        result += takeCount;
        k -= takeCount;

        takeCount = Math.Min(numZeros, k);
        k -= takeCount;

        takeCount = Math.Min(numNegOnes, k);
        result -= takeCount;

        return result;
    }
}
