using System.Text;

namespace LeetCode.Problems._1957_Delete_Characters_to_Make_Fancy_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1439439875/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string MakeFancyString(string s)
    {
        if (s.Length < 3)
        {
            return s;
        }

        var sb = new StringBuilder(s[..2]);
        var isPair = sb[0] == sb[1];

        for (var i = 2; i < s.Length; i++)
        {
            if (isPair && s[i] == sb[^1])
            {
                continue;
            }

            sb.Append(s[i]);
            isPair = sb[^1] == sb[^2];
        }

        return sb.ToString();
    }
}
