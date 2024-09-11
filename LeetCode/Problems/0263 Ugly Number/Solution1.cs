using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0263_Ugly_Number;

/// <summary>
/// https://leetcode.com/problems/ugly-number/submissions/845545807/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public bool IsUgly(int n)
    {
        if (n < 0)
        {
            return false;
        }

        var primeFactors = new[] { 2, 3, 5 };

        foreach (var p in primeFactors)
        {
            while (n % p == 0)
            {
                n /= p;
            }
        }

        return n == 1;
    }
}
