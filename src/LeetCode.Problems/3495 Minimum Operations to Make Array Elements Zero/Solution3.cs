namespace LeetCode.Problems._3495_Minimum_Operations_to_Make_Array_Elements_Zero;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-make-array-elements-zero/submissions/1760983897/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long MinOperations(int[][] queries) => queries.Sum(query => CountOperations(query[0], query[1]));

    private static long CountOperations(int l, int r)
    {
        const int maxFourPower = 14;
        var powerOfFour = 1L;
        var sum = 0L;

        for (var i = 0; i <= maxFourPower; i++)
        {
            var previousPowerOfFour = powerOfFour;
            powerOfFour *= 4;

            if (powerOfFour <= l)
            {
                continue;
            }

            sum += 1L * ((Math.Min(r, powerOfFour - 1) - Math.Max(l, previousPowerOfFour) + 1) * (i + 1));

            if (powerOfFour > r)
            {
                break;
            }
        }

        return (sum + 1) / 2;
    }
}
