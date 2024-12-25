namespace LeetCode.Problems._2832_Maximal_Range_That_Each_Element_Is_Maximum_in_It;

/// <summary>
/// https://leetcode.com/submissions/detail/1479789937/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MaximumLengthOfRanges(int[] nums)
    {
        var n = nums.Length;
        var stack = new Stack<int>();

        var smallerCountsToTheRight = new int[n];

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            while (stack.Count > 0 && nums[stack.Peek()] < num)
            {
                var smallerIndex = stack.Pop();
                smallerCountsToTheRight[smallerIndex] = i - smallerIndex - 1;
            }

            stack.Push(i);
        }

        while (stack.Count > 0)
        {
            var smallerIndex = stack.Pop();
            smallerCountsToTheRight[smallerIndex] = n - smallerIndex - 1;
        }

        var smallerCountsToTheLeft = new int[n];

        for (var i = n - 1; i >= 0; i--)
        {
            var num = nums[i];
            while (stack.Count > 0 && nums[stack.Peek()] < num)
            {
                var smallerIndex = stack.Pop();
                smallerCountsToTheLeft[smallerIndex] = smallerIndex - i - 1;
            }

            stack.Push(i);
        }

        while (stack.Count > 0)
        {
            var smallerIndex = stack.Pop();
            smallerCountsToTheLeft[smallerIndex] = smallerIndex;
        }

        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            ans[i] = smallerCountsToTheLeft[i] + smallerCountsToTheRight[i] + 1;
        }

        return ans;
    }
}
