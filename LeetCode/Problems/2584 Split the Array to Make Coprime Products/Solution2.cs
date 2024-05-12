using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._2584_Split_the_Array_to_Make_Coprime_Products;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-335/submissions/detail/909291988/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FindValidSplit(int[] nums)
    {
        var n = nums.Length;

        if (n == 1)
        {
            return -1;
        }

        var resultProduct = new BigInteger(nums[0]);
        var result = 0;
        var product = resultProduct;

        for (var i = 1; i <= n - 1; i++)
        {
            var num = nums[i];
            product *= num;

            if (BigInteger.GreatestCommonDivisor(resultProduct, num) == 1)
            {
                continue;
            }

            result = i;
            resultProduct = product;
        }

        return result <= n - 2 ? result : -1;
    }
}
