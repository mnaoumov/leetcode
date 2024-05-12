using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._1021_Remove_Outermost_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/926843404/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string RemoveOuterParentheses(string s)
    {
        var start = 0;
        var balance = 0;
        var sb = new StringBuilder();

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                balance++;
            }
            else
            {
                balance--;

                if (balance != 0)
                {
                    continue;
                }

                sb.Append(s[(start + 1)..i]);
                start = i + 1;
            }
        }

        return sb.ToString();
    }
}
