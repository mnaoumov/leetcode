using JetBrains.Annotations;

namespace LeetCode._0633_Sum_of_Square_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/928786665/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool JudgeSquareSum(int c)
    {
        var max = (int) Math.Sqrt(c / 2d);

        for (var a = 0; a <= max; a++)
        {
            var b2 = c - a * a;
            var b = (int) Math.Sqrt(b2);

            if (b * b == b2)
            {
                return true;
            }
        }

        return false;
    }
}
