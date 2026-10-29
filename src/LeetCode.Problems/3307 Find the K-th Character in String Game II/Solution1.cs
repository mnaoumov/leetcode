namespace LeetCode.Problems._3307_Find_the_K_th_Character_in_String_Game_II;

/// <summary>
/// https://leetcode.com/problems/find-the-k-th-character-in-string-game-ii/submissions/1685584375/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public char KthCharacter(long k, int[] operations)
    {
        const int lettersCount = 26;
        var offset = 0;

        while (k > 1)
        {
            var exponent = (int) Math.Log2(k);
            var powerOf2 = 1L << exponent;

            if (powerOf2 == k)
            {
                exponent--;
                powerOf2 /= 2;
            }

            offset = (offset + operations[exponent]) % lettersCount;
            k -= powerOf2;
        }

        return (char) ('a' + offset);
    }
}
