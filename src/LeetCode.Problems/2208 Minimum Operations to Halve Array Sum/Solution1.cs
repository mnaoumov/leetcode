namespace LeetCode.Problems._2208_Minimum_Operations_to_Halve_Array_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/907463895/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int HalveArray(int[] nums)
    {
        var heap = new PriorityQueue<double, double>();

        foreach (var num in nums)
        {
            heap.Enqueue(num, -num);
        }

        var sumToReduce = nums.Select(num => (double) num).Sum() / 2;

        var result = 0;

        while (sumToReduce > 0)
        {
            var max = heap.Dequeue();
            heap.Enqueue(max / 2, -max / 2);
            sumToReduce -= max / 2;
            result++;
        }

        return result;
    }
}
