using JetBrains.Annotations;

namespace LeetCode._0503_Next_Greater_Element_II;

/// <summary>
/// https://leetcode.com/submissions/detail/935608230/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] NextGreaterElements(int[] nums)
    {
        var n = nums.Length;
        var ans = new int[n];
        var stack = new Stack<int>();

        for (var i = 0; i < n; i++)
        {
            while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
            {
                ans[stack.Pop()] = nums[i];
            }

            stack.Push(i);
        }

        for (var i = 0; i < n; i++)
        {
            while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
            {
                ans[stack.Pop()] = nums[i];
            }
        }

        while (stack.Count > 0)
        {
            ans[stack.Pop()] = -1;
        }

        return ans;
    }
}
