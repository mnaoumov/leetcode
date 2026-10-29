namespace LeetCode.Problems._2593_Find_Score_of_an_Array_After_Marking_All_Elements;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-100/submissions/detail/917509998/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long FindScore(int[] nums)
    {
        var pq = new PriorityQueue<int, (int num, int index)>();
        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            pq.Enqueue(i, (nums[i], i));
        }

        var marked = new bool[n];

        var score = 0L;

        while (pq.Count > 0)
        {
            var index = pq.Dequeue();

            if (marked[index])
            {
                continue;
            }

            score += nums[index];
            marked[index] = true;

            if (index > 0)
            {
                marked[index - 1] = true;
            }

            if (index < n - 1)
            {
                marked[index + 1] = true;
            }
        }

        return score;
    }
}
