using System.Text;

namespace LeetCode.Problems._3612_Process_String_with_Special_Operations_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-458/problems/process-string-with-special-operations-i/submissions/1695807832/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ProcessStr(string s)
    {
        var sb = new StringBuilder();

        foreach (var symbol in s)
        {
            if (char.IsLetter(symbol))
            {
                sb.Append(symbol);
            }
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            else if (symbol == '*')
            {
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
            }
            else if (symbol == '#')
            {
                if (sb.Length > 0)
                {
                    sb.Append(sb.ToString());
                }
            }
            else if (symbol == '%')
            {
                var reversed = string.Concat(sb.ToString().Reverse());
                sb.Clear();
                sb.Append(reversed);
            }
        }

        return sb.ToString();
    }
}
