namespace LeetCode.Problems._3598_Longest_Common_Prefix_Between_Adjacent_Strings_After_Removals;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-456/problems/longest-common-prefix-between-adjacent-strings-after-removals/submissions/1679897842/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] LongestCommonPrefix(string[] words)
    {
        var n = words.Length;

        var lcpLength = new int[n - 1];

        for (var i = 0; i < n - 1; i++)
        {
            lcpLength[i] = GetLongestCommonPrefixLength(words[i], words[i + 1]);
        }

        var maxLcpLengthBefore = new int[n - 1];

        for (var i = 0; i < n - 1; i++)
        {
            maxLcpLengthBefore[i] = Math.Max(i > 0 ? maxLcpLengthBefore[i - 1] : 0, lcpLength[i]);
        }

        var maxLcpLengthAfter = new int[n - 1];

        for (var i = n - 2; i >= 0; i--)
        {
            maxLcpLengthAfter[i] = Math.Max(i < n - 2 ? maxLcpLengthAfter[i + 1] : 0, lcpLength[i]);
        }

        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            ans[i] = Math.Max(ans[i], i >= 2 ? maxLcpLengthBefore[i - 2] : 0);
            ans[i] = Math.Max(ans[i], i <= n - 3 ? maxLcpLengthAfter[i + 1] : 0);
            ans[i] = Math.Max(ans[i], i >= 1 && i <= n - 2 ? GetLongestCommonPrefixLength(words[i - 1], words[i+1]) : 0);
        }

        return ans;
    }

    private static int GetLongestCommonPrefixLength(string word1, string word2)
    {
        var ans = 0;

        var minLength = Math.Min(word1.Length, word2.Length);

        for (var j = 0; j < minLength; j++)
        {
            if (word1[j] != word2[j])
            {
                break;
            }

            ans++;
        }

        return ans;
    }
}
