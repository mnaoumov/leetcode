namespace LeetCode.Problems._3584_Maximum_Product_of_First_and_Last_Elements_of_a_Subsequence;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-454/problems/maximum-product-of-first-and-last-elements-of-a-subsequence/submissions/1664460171/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumProduct(int[] nums, int m)
    {
        if (m == 1)
        {
            var max = nums.Max();
            var min = nums.Min();

            return Math.Max(1L * max * max, 1L * min * min);
        }

        var counts = new Dictionary<int, int>();
        var mins = new PriorityQueue<int, int>();
        var maxes = new PriorityQueue<int, int>();

        foreach (var num in nums.Skip(m - 1))
        {
            counts.TryAdd(num, 0);
            counts[num]++;
            mins.Enqueue(num, num);
            maxes.Enqueue(num, -num);
        }

        var ans = long.MinValue;

        var n = nums.Length;

        for (var i = 0; i < n - m + 1; i++)
        {
            var num = nums[i];

            var maxProduct = num switch
            {
                0 => 0,
                > 0 => 1L * num * Peek(maxes),
                _ => 1L * num * Peek(mins)
            };

            ans = Math.Max(ans, maxProduct);
            var minSequenceEndIndex = i + m - 1;
            counts[nums[minSequenceEndIndex]]--;
        }

        return ans;

        long Peek(PriorityQueue<int, int> queue)
        {
            while (counts[queue.Peek()] == 0)
            {
                queue.Dequeue();
            }
            return queue.Peek();
        }
    }
}