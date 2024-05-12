using JetBrains.Annotations;

namespace LeetCode.Problems._0456_132_Pattern;

/// <summary>
/// https://leetcode.com/submissions/detail/950366816/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool Find132pattern(int[] nums)
    {
        var stack = new Stack<int>();

        foreach (var num in nums)
        {
            if (stack.Count == 0 || stack.Peek() <= num)
            {
                stack.Push(num);
            }
            else
            {
                while (stack.Count > 0 && stack.Peek() >= num)
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    return true;
                }

                stack.Push(num);
            }
        }

        return false;
    }
}
