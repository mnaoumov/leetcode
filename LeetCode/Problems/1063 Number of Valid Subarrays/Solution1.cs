namespace LeetCode.Problems._1063_Number_of_Valid_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1055938095/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ValidSubarrays(int[] nums)
    {
        var n = nums.Length;
        var lastIndices = Enumerable.Range(0, n).Select(_ => n - 1).ToArray();

        var stack = new Stack<int>();

        for (var i = 0; i < n; i++)
        {
            while (stack.Count > 0 && nums[stack.Peek()] > nums[i])
            {
                lastIndices[stack.Pop()] = i - 1;
            }

            stack.Push(i);
        }

        return lastIndices.Select((lastIndex, firstIndex) => lastIndex - firstIndex + 1).Sum();
    }
}
