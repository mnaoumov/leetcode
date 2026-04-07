using System.Text;

namespace LeetCode.Problems._3849_Maximum_Bitwise_XOR_After_Rearrangement;

/// <summary>
/// leetcode.com/contest/weekly-contest-490/problems/maximum-bitwise-xor-after-rearrangement/submissions/1926940808/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MaximumXor(string s, string t)
    {
        var n = t.Length;
        var zeroCounts = t.Count(digitChar => digitChar == '0');
        var counts = new[] { zeroCounts, n - zeroCounts };

        var sb = new StringBuilder
        {
            Length = n
        };

        for (var i = 0; i < n; i++)
        {
            var sDigit = s[i] - '0';
            var desiredDigit = sDigit ^ 1;

            if (counts[desiredDigit] == 0)
            {
                desiredDigit = sDigit;
            }

            sb[i] = (char) ('0' + (sDigit ^ desiredDigit));

            counts[desiredDigit]--;
        }

        return sb.ToString();
    }
}
