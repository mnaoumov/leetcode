namespace LeetCode.Problems._0367_Valid_Perfect_Square;

/// <summary>
/// https://leetcode.com/submissions/detail/924590055/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPerfectSquare(int num)
    {
        const int maxSqrt = 46340; // Math.Sqrt(int.MaxValue)

        var low = 1;
        var high = maxSqrt;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            var sqr = mid * mid;

            if (sqr < num)
            {
                low = mid + 1;
            }
            else if (sqr > num)
            {
                high = mid - 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
