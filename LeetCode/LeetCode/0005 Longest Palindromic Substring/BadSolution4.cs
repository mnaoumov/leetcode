namespace LeetCode._0005_Longest_Palindromic_Substring;

/// <summary>
/// https://leetcode.com/submissions/detail/147569862/
/// </summary>
public class BadSolution4 : ISolution
{
    public string LongestPalindrome(string s)
    {
        var max = "";
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + max.Length; j < s.Length; j++)
            {
                var sub = s.Substring(i, j - i + 1);
                if (max.Length < sub.Length && IsPalindrome(sub))
                    max = sub;
            }
        }

        return max;
    }

    private bool IsPalindrome(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
                return false;
        }

        return true;
    }
}