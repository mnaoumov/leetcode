using JetBrains.Annotations;

namespace LeetCode._0125_Valid_Palindrome;

/// <summary>
/// https://leetcode.com/submissions/detail/836402216/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPalindrome(string s)
    {
        var startIndex = 0;
        var endIndex = s.Length - 1;

        while (true)
        {
            while (startIndex < s.Length && !char.IsLetterOrDigit(s[startIndex]))
            {
                startIndex++;
            }

            while (endIndex >= 0 && !char.IsLetterOrDigit(s[endIndex]))
            {
                endIndex--;
            }

            if (startIndex > endIndex)
            {
                return true;
            }

            if (char.ToLower(s[startIndex]) != char.ToLower(s[endIndex]))
            {
                return false;
            }

            startIndex++;
            endIndex--;
        }
    }
}
