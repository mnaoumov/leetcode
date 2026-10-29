namespace LeetCode.Problems._2749_Minimum_Operations_to_Make_the_Integer_Zero;

/// <summary>
/// https://leetcode.com/submissions/detail/982106911/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MakeTheIntegerZero(int num1, int num2)
    {
        long num = num1;

        for (var i = 1; i <= 60; i++)
        {
            num -= num2;

            if (num <= 0)
            {
                return -1;
            }

            var bitCount = BitCount(num);

            if (bitCount <= i && i <= num)
            {
                return i;
            }
        }

        return -1;
    }

    private static int BitCount(long num)
    {
        var ans = 0;

        while (num > 0)
        {
            ans += (int) (num & 1L);
            num >>= 1;
        }

        return ans;
    }
}
