namespace LeetCode.Problems._2543_Check_if_Point_Is_Reachable;

/// <summary>
/// https://leetcode.com/submissions/detail/882546878/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsReachable(int targetX, int targetY) => IsPowerOfTwo(Gcd(targetX, targetY));

    private static bool IsPowerOfTwo(int n)
    {
        while (n % 2 == 0)
        {
            n >>= 1;
        }

        return n == 1;
    }

    private static int Gcd(int a, int b)
    {
        while (b > 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }
}
