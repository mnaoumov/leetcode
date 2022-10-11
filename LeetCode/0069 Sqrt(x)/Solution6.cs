namespace LeetCode._0069_Sqrt_x_;

/// <summary>
/// https://leetcode.com/submissions/detail/820356584/
/// </summary>
public class Solution6 : ISolution
{
    public int MySqrt(int x)
    {
        const int maxResult = 46340; // Math.Sqrt(int.MaxValue)

        if (maxResult * maxResult <= x)
        {
            return maxResult;
        }

        var left = 0;
        var right = Math.Min(maxResult, x);

        while (left <= right)
        {
            var mid = (left + right) / 2;
            var square = mid * mid;

            if (square < x)
            {
                left = mid + 1;
            }
            else if (square > x)
            {
                right = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return left - 1;
    }
}