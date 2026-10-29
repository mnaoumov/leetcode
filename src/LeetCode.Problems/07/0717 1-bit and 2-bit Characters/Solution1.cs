namespace LeetCode.Problems._0717_1_bit_and_2_bit_Characters;

/// <summary>
/// https://leetcode.com/problems/1-bit-and-2-bit-characters/submissions/1832811167/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsOneBitCharacter(int[] bits)
    {
        if (bits[^1] != 0)
        {
            return false;
        }

        var i = 0;
        var n = bits.Length;

        while (i < n)
        {
            if (i == n - 1)
            {
                return true;
            }

            if (bits[i] == 0)
            {
                i++;
                continue;
            }

            i += 2;
        }

        return false;
    }
}
