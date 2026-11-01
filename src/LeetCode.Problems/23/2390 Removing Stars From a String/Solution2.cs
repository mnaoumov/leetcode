using System.Text;

namespace LeetCode.Problems._2390_Removing_Stars_From_a_String;

/// <seealso href="https://leetcode.com/submissions/detail/902685766/">Submission</seealso>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string RemoveStars(string s)
    {
        var sb = new StringBuilder();

        foreach (var symbol in s)
        {
            if (symbol != '*')
            {
                sb.Append(symbol);
            }
            else
            {
                sb.Remove(sb.Length - 1, 1);
            }
        }

        return sb.ToString();
    }
}
