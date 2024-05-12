using JetBrains.Annotations;

namespace LeetCode.Problems._0338_Counting_Bits;

/// <summary>
/// https://leetcode.com/submissions/detail/926889727/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] CountBits(int n)
    {
        var powerOfTwo = 1;
        var nextPowerOfTwo = 2;
        var ans = new int[n + 1];

        for (var i = 1; i <= n; i++)
        {
            if (i == nextPowerOfTwo)
            {
                powerOfTwo = nextPowerOfTwo;
                nextPowerOfTwo <<= 1;
            }

            ans[i] = 1 + ans[i - powerOfTwo];
        }

        return ans;
    }
}
