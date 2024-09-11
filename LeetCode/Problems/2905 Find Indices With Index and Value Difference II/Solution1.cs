namespace LeetCode.Problems._2905_Find_Indices_With_Index_and_Value_Difference_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-367/submissions/detail/1075471687/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
    {
        var n = nums.Length;
        var minIndices = new PriorityQueue<int, int>();
        var maxIndices = new PriorityQueue<int, int>();

        for (var j = indexDifference; j < n; j++)
        {
            minIndices.Enqueue(j, nums[j]);
            maxIndices.Enqueue(j, -nums[j]);
        }

        for (var i = 0; i < n - indexDifference; i++)
        {
            while (minIndices.Peek() < i + indexDifference)
            {
                minIndices.Dequeue();
            }

            while (maxIndices.Peek() < i + indexDifference)
            {
                maxIndices.Dequeue();
            }

            var minIndex = minIndices.Peek();
            var maxIndex = maxIndices.Peek();

            if (Math.Abs(nums[minIndex] - nums[i]) >= valueDifference)
            {
                return new[] { i, minIndex };
            }

            if (Math.Abs(nums[maxIndex] - nums[i]) >= valueDifference)
            {
                return new[] { i, maxIndex };
            }
        }

        return new[] { -1, -1 };
    }
}
