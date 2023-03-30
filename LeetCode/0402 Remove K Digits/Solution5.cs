using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0402_Remove_K_Digits;

/// <summary>
/// https://leetcode.com/submissions/detail/924514036/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    // ReSharper disable once IdentifierTypo
    public string RemoveKdigits(string num, int k)
    {
        var stack = new Stack<char>();

        foreach (var digit in num)
        {
            while (stack.Count > 0 && stack.Peek() > digit && k > 0)
            {
                stack.Pop();
                k--;
            }

            if (stack.Count > 0 || digit != '0')
            {
                stack.Push(digit);
            }
        }

        while (stack.Count > 0 && k > 0)
        {
            stack.Pop();
            k--;
        }

        for (var i = 0; i < k; i++)
        {
            if (stack.Count == 0)
            {
                break;
            }

            stack.Pop();
        }

        if (stack.Count == 0)
        {
            stack.Push('0');
        }

        var sb = new StringBuilder();

        while (stack.Count > 0)
        {
            sb.Insert(0, stack.Pop());
        }

        return sb.ToString();
    }
}
