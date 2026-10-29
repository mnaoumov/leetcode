namespace LeetCode.Problems._1944_Number_of_Visible_People_in_a_Queue;

/// <summary>
/// https://leetcode.com/submissions/detail/903675338/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] CanSeePersonsCount(int[] heights)
    {
        var n = heights.Length;
        var result = new int[n];

        var stack = new Stack<int>();

        for (var i = n - 1; i >= 0; i--)
        {
            var height = heights[i];

            while (stack.TryPeek(out var previousHeight) && height > previousHeight)
            {
                result[i]++;
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                result[i]++;
            }

            stack.Push(height);
        }

        return result;
    }
}
