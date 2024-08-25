using System.Numerics;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace LeetCode.Problems._0592_Fraction_Addition_and_Subtraction;

/// <summary>
/// https://leetcode.com/submissions/detail/1365199118/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FractionAddition(string expression)
    {
        var ansNumerator = 0L;

        const int lcm = 2520; // LCM of 1..10

        foreach (Match match in Regex.Matches(expression, @"(?<Sign>^|[+-])(?<Numerator>\d+)/(?<Denominator>\d+)"))
        {
            var sign = match.Groups["Sign"].Value == "-" ? -1 : 1;
            var numerator = Convert.ToInt32(match.Groups["Numerator"].Value);
            var denominator = Convert.ToInt32(match.Groups["Denominator"].Value);
            ansNumerator += sign * numerator * (lcm / denominator);
        }

        var ansSign = ansNumerator < 0 ? "-" : "";
        ansNumerator = Math.Abs(ansNumerator);
        var gcd = (int) BigInteger.GreatestCommonDivisor(ansNumerator, lcm);
        ansNumerator /= gcd;
        var ansDenominator = lcm / gcd;
        return $"{ansSign}{ansNumerator}/{ansDenominator}";
    }
}
