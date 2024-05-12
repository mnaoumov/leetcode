using JetBrains.Annotations;

namespace LeetCode.Problems._2772_Apply_Operations_to_Make_All_Array_Elements_Equal_to_Zero;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-353/submissions/detail/989843518/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool CheckArray(int[] nums, int k)
    {
        var decrements = new Queue<int>();
        var decrement = 0;
        var n = nums.Length;

        for (var i = 0; i < n; i++)
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

            if (i > n - k && diff != 0)
            {
                return false;
            }

            decrements.Enqueue(diff);
            decrement += diff;
        }

        return true;
    }
}
