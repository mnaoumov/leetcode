using JetBrains.Annotations;

namespace LeetCode._0000_Calculate_Entropy;

/// <summary>
/// https://leetcode.com/explore/learn/card/decision-tree/285/implementation/2650/
/// </summary>
[PublicAPI]
public interface ISolution
{
    public double CalculateEntropy(int[] input);
}
