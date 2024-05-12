using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode.Problems._2654_Minimum_Number_of_Operations_to_Make_All_Array_Elements_Equal_to_1;

/// <summary>
/// https://leetcode.com/submissions/detail/938460214/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var n = nums.Length;
        var gcds = nums.ToArray();

        var minDistance = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            for (var j = i; j >= Math.Max(0, i - minDistance); j--)
            {
                gcds[j] = (int) BigInteger.GreatestCommonDivisor(gcds[j], nums[i]);

                if (gcds[j] != 1)
                {
                    continue;
                }

                minDistance = i - j;

                if (minDistance == 0)
                {
                    break;
                }
            }
        }

        if (minDistance == int.MaxValue)
        {
            return -1;
        }

        return minDistance == 0 ? nums.Count(num => num != 1) : minDistance + nums.Length - 1;
    }
}
