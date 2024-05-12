using JetBrains.Annotations;

namespace LeetCode.Problems._2917_Find_the_K_or_of_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-369/submissions/detail/1086461887/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindKOr(int[] nums, int k)
    {
        const int maxBitCount = 31;
        var bitsCount = new int[maxBitCount];

        foreach (var num in nums)
        {
            var num1 = num;

            for (var i = 0; i < maxBitCount; i++)
            {
                if (num1 == 0)
                {
                    break;
                }

                if ((num1 & 1) == 1)
                {
                    bitsCount[i]++;
                }

                num1 >>= 1;
            }
        }

        var ans = 0;

        for (var i = 0; i < maxBitCount; i++)
        {
            if (bitsCount[i] >= k)
            {
                ans |= 1 << i;
            }
        }

        return ans;
    }
}
