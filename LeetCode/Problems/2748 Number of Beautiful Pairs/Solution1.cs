using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._2748_Number_of_Beautiful_Pairs;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-351/submissions/detail/978919922/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountBeautifulPairs(int[] nums)
    {
        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var digit1 = nums[i];

            while (digit1 > 10)
            {
                digit1 /= 10;
            }

            for (var j = i + 1; j < nums.Length; j++)
            {
                var digit2 = nums[j] % 10;

                if (BigInteger.GreatestCommonDivisor(digit1, digit2) == 1)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
