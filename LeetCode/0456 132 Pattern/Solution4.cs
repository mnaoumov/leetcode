using JetBrains.Annotations;

namespace LeetCode._0456_132_Pattern;

/// <summary>
/// https://leetcode.com/submissions/detail/950409333/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public bool Find132pattern(int[] nums)
    {
        var n = nums.Length;
        var mins = new int[n];
        mins[0] = nums[0];

        for (var i = 1; i < n; i++)
        {
            mins[i] = Math.Min(mins[i - 1], nums[i]);
        }

        var stack = new Stack<int>();

        for (var j = n - 1; j >= 0; j--)
        {
            while (stack.Count > 0 && stack.Peek() <= mins[j])
            {
                stack.Pop();
            }

            if (stack.Count > 0 && stack.Peek() < nums[j])
            {
                return true;
            }

            stack.Push(nums[j]);
        }

        return false;
    }
}
