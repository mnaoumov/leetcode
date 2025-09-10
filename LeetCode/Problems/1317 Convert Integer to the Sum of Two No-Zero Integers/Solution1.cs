namespace LeetCode.Problems._1317_Convert_Integer_to_the_Sum_of_Two_No_Zero_Integers;

/// <summary>
/// https://leetcode.com/problems/convert-integer-to-the-sum-of-two-no-zero-integers/submissions/1763213035/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] GetNoZeroIntegers(int n)
    {
        for (var a = 0; a <= n / 2; a++)
        {
            var b = n - a;

            if (IsNoZero(a) && IsNoZero(b))
            {
                return new[] { a, b };
            }
        }

        throw new InvalidOperationException();
    }

    private static bool IsNoZero(int n) => !n.ToString().Contains('0');
}
