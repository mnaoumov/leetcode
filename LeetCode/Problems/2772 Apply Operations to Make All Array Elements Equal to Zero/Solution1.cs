using JetBrains.Annotations;

namespace LeetCode._2772_Apply_Operations_to_Make_All_Array_Elements_Equal_to_Zero;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-353/submissions/detail/989836185/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool CheckArray(int[] nums, int k)
    {
        var decrements = new Queue<int>();
        var decrement = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (i >= k)
            {
                decrement -= decrements.Dequeue();
            }

            if (num < decrement)
            {
                return false;
            }

            var diff = num - decrement;
            decrements.Enqueue(diff);
            decrement += diff;
        }

        return true;
    }
}
