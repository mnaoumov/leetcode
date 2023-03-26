using JetBrains.Annotations;

namespace LeetCode._0000_Calculate_Entropy;

/// <summary>
/// https://leetcode.com/submissions/detail/922125152
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public double CalculateEntropy(int[] input)
    {
        if (input.Length == 0)
        {
            return 0d;
        }

        var probabilities = input.GroupBy(num => num).Select(g => 1d * g.Count() / input.Length);
        return -probabilities.Sum(p => p * Math.Log2(p));
    }
}
