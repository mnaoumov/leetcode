namespace LeetCode.Problems._2530_Maximal_Score_After_Applying_K_Operations;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-327/submissions/detail/873718507/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxKelements(int[] nums, int k)
    {
        var pq = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            pq.Enqueue(num, -num);
        }

        long result = 0;

        for (var i = 0; i < k; i++)
        {
            var max = pq.Dequeue();
            result += max;
            var newValue = (max + 2) / 3;
            pq.Enqueue(newValue, -newValue);
        }

        return result;
    }
}
