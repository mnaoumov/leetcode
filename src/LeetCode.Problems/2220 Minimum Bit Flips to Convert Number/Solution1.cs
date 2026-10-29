namespace LeetCode.Problems._2220_Minimum_Bit_Flips_to_Convert_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/1386223134/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinBitFlips(int start, int goal) => CountBits(start ^ goal);

    private static int CountBits(int num)
    {
        var ans = 0;

        while (num > 0)
        {
            ans += num & 1;
            num >>= 1;
        }

        return ans;
    }
}
