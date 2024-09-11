namespace LeetCode.Problems._3264_Final_Array_State_After_K_Multiplication_Operations_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-412/submissions/detail/1367291266/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        var pq = new PriorityQueue<(int num, int index), (int num, int index)>();
        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            var tuple = (nums[i], i);
            pq.Enqueue(tuple, tuple);
        }

        for (var i = 0; i < k; i++)
        {
            var (num, index) = pq.Dequeue();
            var tuple = (num * multiplier, index);
            pq.Enqueue(tuple, tuple);
        }

        var ans = new int[n];

        while (pq.Count > 0)
        {
            var (num, index) = pq.Dequeue();
            ans[index] = num;
        }

        return ans;
    }
}
