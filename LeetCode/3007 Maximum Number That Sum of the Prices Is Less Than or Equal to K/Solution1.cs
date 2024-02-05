using JetBrains.Annotations;

namespace LeetCode._3007_Maximum_Number_That_Sum_of_the_Prices_Is_Less_Than_or_Equal_to_K;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long FindMaximumNumber(long k, int x)
    {
        var i = 1 << x - 1;

        var min = 1;
        var max = long.MaxValue;

        while (min <= max)
        {
            var mid = min + (max - min >> 1);

            var t = 1L;

            while (t <= mid)
            {

                t *= 2;
            }
        }

        return 0;
    }
}
