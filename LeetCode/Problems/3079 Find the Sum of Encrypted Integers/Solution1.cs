using JetBrains.Annotations;

namespace LeetCode.Problems._3079_Find_the_Sum_of_Encrypted_Integers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-126/submissions/detail/1205315993/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOfEncryptedInt(int[] nums)
    {
        var ans = 0;

        foreach (var num in nums)
        {
            var temp = num;
            var maxDigit = 0;
            var digitCount = 0;

            while (temp > 0)
            {
                var digit = temp % 10;
                maxDigit = Math.Max(maxDigit, digit);
                digitCount++;
                temp /= 10;
            }

            var newNum = 0;

            for (var i = 0; i < digitCount; i++)
            {
                newNum = 10 * newNum + maxDigit;
            }

            ans += newNum;
        }

        return ans;
    }
}
