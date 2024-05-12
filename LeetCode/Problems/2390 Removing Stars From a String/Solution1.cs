using System.Text;
using JetBrains.Annotations;

namespace LeetCode._2390_Removing_Stars_From_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/902685152/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string RemoveStars(string s)
    {
        var stack = new Stack<char>();

        foreach (var symbol in s)
        {
            if (symbol != '*')
            {
                stack.Push(symbol);
            }
            else
            {
                stack.Pop();
            }
        }

        var sb = new StringBuilder();

        while (stack.Count > 0)
        {
            sb.Insert(0, stack.Pop());
        }

        return sb.ToString();
    }
}
