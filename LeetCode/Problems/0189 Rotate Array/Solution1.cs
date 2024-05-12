using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode.Problems._0189_Rotate_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/922813832/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void Rotate(int[] nums, int k)
    {
        var n = nums.Length;
        k %= n;

        if (k == 0)
        {
            return;
        }

        var d = (int) BigInteger.GreatestCommonDivisor(n, k);

        for (var i = 0; i < d; i++)
        {
            var value = nums[i];
            var index = i;

            while (true)
            {
                index = (index + k) % n;
                (nums[index], value) = (value, nums[index]);

                if (index == i)
                {
                    break;
                }
            }
        }
    }
}
