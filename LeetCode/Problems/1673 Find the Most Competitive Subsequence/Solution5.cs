using JetBrains.Annotations;

namespace LeetCode.Problems._1673_Find_the_Most_Competitive_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/903586422/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int[] MostCompetitive(int[] nums, int k)
    {
        var stack = new Stack<int>();
        var possibleSkipCount = nums.Length - k;

        foreach (var num in nums)
        {
            while (possibleSkipCount > 0 && stack.TryPeek(out var lastNum) && lastNum > num)
            {
                possibleSkipCount--;
                stack.Pop();
            }

            if (stack.Count < k)
            {
                stack.Push(num);
            }
            else
            {
                possibleSkipCount--;
            }
        }

        return stack.Reverse().ToArray();
    }
}
