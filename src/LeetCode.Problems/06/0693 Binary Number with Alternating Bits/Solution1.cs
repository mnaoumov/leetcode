namespace LeetCode.Problems._0693_Binary_Number_with_Alternating_Bits;

/// <summary>
/// https://leetcode.com/problems/binary-number-with-alternating-bits/submissions/1922734858/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasAlternatingBits(int n)
    {
        var previousHasLastBit = !HasLastBit(n);

        while (n > 0)
        {
            var hasLastBit = HasLastBit(n);
            if (hasLastBit == previousHasLastBit)
            {
                return false;
            }

            n >>= 1;
            previousHasLastBit = hasLastBit;
        }

        return true;
    }

    private static bool HasLastBit(int n) => (n & 1) == 1;
}
