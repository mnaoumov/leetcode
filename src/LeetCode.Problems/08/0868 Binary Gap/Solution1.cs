namespace LeetCode.Problems._0868_Binary_Gap;

/// <summary>
/// https://leetcode.com/problems/binary-gap/submissions/1926832792/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int BinaryGap(int n)
    {
        const int notFound = -1;
        var lastOneBit = notFound;
        var ans = 0;
        var bit = 0;

        while (n > 0)
        {
            var hasOneBit = (n & 1) == 1;

            if (hasOneBit)
            {
                if (lastOneBit != notFound)
                {
                    ans = Math.Max(ans, bit - lastOneBit);
                }

                lastOneBit = bit;
            }

            n >>= 1;
            bit++;
        }

        return ans;
    }
}
