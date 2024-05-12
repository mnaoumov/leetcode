using JetBrains.Annotations;

namespace LeetCode.Problems._3113_Find_the_Number_of_Subarrays_Where_Boundary_Elements_Are_Maximum;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-128/submissions/detail/1231302341/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long NumberOfSubarrays(int[] nums)
    {
        var nonIncreasingStack = new Stack<int>();
        var counts = new Dictionary<int, int>();
        var ans = 0L;

        foreach (var num in nums)
        {
            while (nonIncreasingStack.Count > 0 && nonIncreasingStack.Peek() < num)
            {
                var oldNum = nonIncreasingStack.Pop();
                counts.Remove(oldNum);
            }

            counts.TryAdd(num, 0);
            counts[num]++;
            ans += counts[num];
            nonIncreasingStack.Push(num);
        }

        return ans;
    }
}
