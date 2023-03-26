using JetBrains.Annotations;

namespace LeetCode._0000_Calculate_Entropy;

/// <summary>
/// https://leetcode.com/submissions/detail/922121664/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public double CalculateEntropy(int[] input)
    {
        var probabilities = input.GroupBy(num => num).Select(g => 1d * g.Count() / input.Length);
        return -probabilities.Sum(p => p * Math.Log2(p));
    }
}
