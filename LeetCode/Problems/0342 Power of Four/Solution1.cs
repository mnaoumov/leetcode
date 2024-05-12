using JetBrains.Annotations;

namespace LeetCode.Problems._0342_Power_of_Four;

/// <summary>
/// https://leetcode.com/submissions/detail/1081712202/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPowerOfFour(int n) => IsSquare(n) && IsPowerOfTwo((int) Math.Sqrt(n));

    private static bool IsSquare(int n)
    {
        if (n < 0)
        {
            return false;
        }

        var m = (int) Math.Sqrt(n);
        return m * m == n;
    }

    private static bool IsPowerOfTwo(int n) => n > 0 && (n & n - 1) == 0;
}
