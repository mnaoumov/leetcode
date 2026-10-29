namespace LeetCode.Problems._1888_Minimum_Number_of_Flips_to_Make_the_Binary_String_Alternating;

/// <summary>
/// https://leetcode.com/problems/minimum-number-of-flips-to-make-the-binary-string-alternating/submissions/1942607472/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinFlips(string s)
    {
        var n = s.Length;

        var zeroStartParityCounts = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            if (i > 0)
            {
                zeroStartParityCounts[i + 1] = zeroStartParityCounts[i];
            }

            if ((s[i] == '0') ^ ((i & 1) == 0))
            {
                zeroStartParityCounts[i + 1]++;
            }
        }

        var ans = Math.Min(zeroStartParityCounts[n], n- zeroStartParityCounts[n]);

        if (n % 2 == 0)
        {
            return ans;
        }

        for (var k = 1; k < n; k++)
        {
            var shifted = zeroStartParityCounts[n] - 2 * zeroStartParityCounts[k] + k;
            ans = Math.Min(ans, shifted);
            ans = Math.Min(ans, n - shifted);
        }

        return ans;
    }
}
