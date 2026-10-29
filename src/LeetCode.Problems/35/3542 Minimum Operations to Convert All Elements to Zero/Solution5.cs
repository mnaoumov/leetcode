namespace LeetCode.Problems._3542_Minimum_Operations_to_Convert_All_Elements_to_Zero;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-convert-all-elements-to-zero/submissions/1825596478/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var stack = new Stack<int>();
        var ans = 0;
        foreach (var num in nums)
        {
            while (stack.Count > 0 && stack.Peek() > num)
            {
                stack.Pop();
            }

            if (num == 0)
            {
                continue;
            }

            if (stack.Count > 0 && stack.Peek() >= num)
            {
                continue;
            }

            ans++;
            stack.Push(num);
        }

        return ans;
    }
}