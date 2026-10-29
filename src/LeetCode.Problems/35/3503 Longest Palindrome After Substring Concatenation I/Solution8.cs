namespace LeetCode.Problems._3503_Longest_Palindrome_After_Substring_Concatenation_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-443/problems/longest-palindrome-after-substring-concatenation-i/submissions/1590707983/
/// </summary>
[UsedImplicitly]
public class Solution8 : ISolution
{
    public int LongestPalindrome(string s, string t) => Math.Max(Impl(s, t), Impl(Reverse(t), Reverse(s)));

    private static int Impl(string s, string t)
    {
        var tSubs = GetSubstrings(t);

        var n = s.Length;
        var ans = 0;

        var maxPalindromeLengths = new int[n + 2];

        for (var j = n; j >= 0; j--)
        {
            for (var i = j - 1; i >= 0; i--)
            {
                var sSub = s[i..j];
                var reverseSSub = Reverse(sSub);
                if (sSub == reverseSSub)
                {
                    ans = Math.Max(ans, sSub.Length);

                    maxPalindromeLengths[i] = Math.Max(maxPalindromeLengths[i], j - i);
                }

                if (tSubs.Contains(reverseSSub))
                {
                    ans = Math.Max(ans, 2 * sSub.Length + maxPalindromeLengths[j]);
                }
            }
        }

        return ans;
    }

    private static string Reverse(string str) => new(str.Reverse().ToArray());

    private static HashSet<string> GetSubstrings(string s)
    {
        var n = s.Length;
        var substrings = new HashSet<string>();
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j <= n; j++)
            {
                substrings.Add(s[i..j]);
            }
        }

        return substrings;
    }
}
