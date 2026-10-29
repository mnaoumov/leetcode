using System.Text;

namespace LeetCode.Problems._3823_Reverse_Letters_Then_Special_Characters_in_a_String;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-175/problems/reverse-letters-then-special-characters-in-a-string/submissions/1903127200/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReverseByType(string s)
    {
        var sb = new StringBuilder(s);

        var letterIndices = new List<int>();
        var specialCharIndices = new List<int>();

        for (var i = 0; i < s.Length; i++)
        {
            var @char = s[i];

            if (char.IsLetter(@char))
            {
                letterIndices.Add(i);
            }
            else
            {
                specialCharIndices.Add(i);
            }
        }

        for (var j = 0; j < letterIndices.Count; j++)
        {
            sb[letterIndices[j]] = s[letterIndices[letterIndices.Count - 1 - j]];
        }

        for (var j = 0; j < specialCharIndices.Count; j++)
        {
            sb[specialCharIndices[j]] = s[specialCharIndices[specialCharIndices.Count - 1 - j]];
        }

        return sb.ToString();
    }
}
