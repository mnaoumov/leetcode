namespace LeetCode.Problems._3767_Maximize_Points_After_Choosing_K_Tasks;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-171/problems/maximize-points-after-choosing-k-tasks/submissions/1848463120/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long MaxPoints(int[] technique1, int[] technique2, int k)
    {
        var n = technique1.Length;
        var ans = 0L;
        var diffs = new PriorityQueue<int, int>();

        for (var i = 0; i < n; i++)
        {
            var diff = technique2[i] - technique1[i];

            if (diff <= 0)
            {
                ans += technique1[i];
                k--;
            }
            else
            {
                ans += technique2[i];
                diffs.Enqueue(diff, diff);
            }
        }

        for (var i = 0; i < k; i++)
        {
            ans -= diffs.Dequeue();
        }

        return ans;
    }
}
