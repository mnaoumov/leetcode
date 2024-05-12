using JetBrains.Annotations;

namespace LeetCode.Problems._2614_Prime_In_Diagonal;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-340/submissions/detail/930421326/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DiagonalPrime(int[][] nums)
    {
        var n = nums.Length;

        var result = 0;

        for (var i = 0; i < n; i++)
        {
            var num = nums[i][i];

            if (IsPrime(num))
            {
                result = Math.Max(result, num);
            }

            if (i == n - 1 - i)
            {
                continue;
            }

            num = nums[i][n - 1 - i];

            if (IsPrime(num))
            {
                result = Math.Max(result, num);
            }
        }

        return result;
    }

    private static bool IsPrime(int num)
    {
        if (num == 1)
        {
            return false;
        }

        for (var j = 2; j * j <= num; j++)
        {
            if (num % j == 0)
            {
                return false;
            }
        }

        return true;
    }
}
