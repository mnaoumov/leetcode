using JetBrains.Annotations;

namespace LeetCode.Problems._0946_Validate_Stack_Sequences;

/// <summary>
/// https://leetcode.com/submissions/detail/932786859/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ValidateStackSequences(int[] pushed, int[] popped)
    {
        var n = pushed.Length;
        var pushIndex = 0;
        var popIndex = 0;
        var stack = new Stack<int>();

        while (pushIndex < n || popIndex < n)
        {
            if (stack.Count > 0 && popIndex < n && popped[popIndex] == stack.Peek())
            {
                stack.Pop();
                popIndex++;
            }
            else if (pushIndex < n)
            {
                stack.Push(pushed[pushIndex]);
                pushIndex++;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
