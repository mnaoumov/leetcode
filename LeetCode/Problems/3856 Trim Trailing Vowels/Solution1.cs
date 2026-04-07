using System.Text;

namespace LeetCode.Problems._3856_Trim_Trailing_Vowels;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-491/problems/trim-trailing-vowels/submissions/1934203343/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string TrimTrailingVowels(string s)
    {
        var sb = new StringBuilder(s);
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        for (var i = sb.Length - 1; i >= 0; i--)
        {
            if (!vowels.Contains(sb[i]))
            {
                break;
            }

            sb.Remove(i, 1);
        }

        return sb.ToString();
    }
}
