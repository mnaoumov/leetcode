using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._2810_Faulty_Keyboard;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-357/submissions/detail/1013403513/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FinalString(string s)
    {
        var sb = new StringBuilder();

        foreach (var letter in s)
        {
            if (letter == 'i')
            {
                for (var j = 0; j < sb.Length / 2; j++)
                {
                    (sb[j], sb[^(j + 1)]) = (sb[^(j + 1)], sb[j]);
                }
            }
            else
            {
                sb.Append(letter);
            }
        }

        return sb.ToString();
    }
}
