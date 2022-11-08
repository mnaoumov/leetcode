using System.Text;
using JetBrains.Annotations;

namespace LeetCode._1544_Make_The_String_Great;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MakeGood(string s)
    {
        var sb = new StringBuilder();

        foreach (var letter in s)
        {
            if (sb.Length == 0)
            {
                sb.Append(letter);
            }
            else
            {
                var lastLetter = sb[^1];

                if (char.ToLower(lastLetter) == char.ToLower(letter) && lastLetter != letter)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(letter);
                }
            }
        }

        return sb.ToString();
    }
}
