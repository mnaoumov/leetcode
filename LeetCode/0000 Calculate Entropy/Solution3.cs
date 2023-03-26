using JetBrains.Annotations;

namespace LeetCode._0000_Calculate_Entropy;

/// <summary>
/// https://leetcode.com/submissions/detail/922125663/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public double CalculateEntropy(int[] input)
    {
        var probabilities = input.GroupBy(num => num).Select(g => 1d * g.Count() / input.Length);
        var result = -probabilities.Sum(p => p * Math.Log2(p));
        return result == 0d ? 0d : result;
    }
}
