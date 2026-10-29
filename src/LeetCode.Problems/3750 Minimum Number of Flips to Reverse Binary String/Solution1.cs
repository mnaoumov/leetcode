namespace LeetCode.Problems._3750_Minimum_Number_of_Flips_to_Reverse_Binary_String;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-170/problems/minimum-number-of-flips-to-reverse-binary-string/submissions/1836815917/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumFlips(int n)
    {
        var temp = n;
        var ans = 0;

        var bits = new List<bool>();

        while (temp > 0)
        {
            var bit = (temp & 1) == 1;
            bits.Insert(0, bit);
            temp >>= 1;
        }

        var m = bits.Count;

        for (var i = 0; i < m / 2; i++)
        {
            if (bits[i] != bits[m - 1 - i])
            {
                ans += 2;
            }
        }

        return ans;
    }
}
