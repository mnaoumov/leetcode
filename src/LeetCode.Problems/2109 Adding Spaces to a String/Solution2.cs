using System.Text;

namespace LeetCode.Problems._2109_Adding_Spaces_to_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1468829224/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string AddSpaces(string s, int[] spaces)
    {
        var sb = new StringBuilder();
        var spaceIndex = 0;

        for (var i = 0; i < s.Length; i++)
        {
            if (spaceIndex < spaces.Length && i == spaces[spaceIndex])
            {
                sb.Append(' ');
                spaceIndex++;
            }
            sb.Append(s[i]);
        }

        return sb.ToString();
    }
}
