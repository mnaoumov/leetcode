using System.Numerics;

namespace LeetCode.Problems._2197_Replace_Non_Coprime_Numbers_in_Array;

/// <summary>
/// https://leetcode.com/problems/replace-non-coprime-numbers-in-array/submissions/1772190800/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<int> ReplaceNonCoprimes(int[] nums)
    {
        var ans = new List<int>();

        foreach (var num in nums)
        {
            var lastValue = ans.Count > 0 ? ans[^1] : 1;
            var gcd = (int) BigInteger.GreatestCommonDivisor(num, lastValue);

            if (gcd == 1)
            {
                ans.Add(num);
            }
            else
            {
                ans[^1] *= num / gcd;
            }
        }

        return ans;
    }
}
