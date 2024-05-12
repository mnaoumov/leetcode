using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._2734_Lexicographically_Smallest_String_After_Substring_Operation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-349/submissions/detail/968503921/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string SmallestString(string s)
    {
        var sb = new StringBuilder(s);

        var hasNotA = false;

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != 'a')
            {
                hasNotA = true;
                sb[i] = (char) (sb[i] - 1);
            }
            else if (hasNotA)
            {
                break;
            }
        }

        if (!hasNotA)
        {
            sb[^1] = 'z';
        }

        return sb.ToString();
    }
}
