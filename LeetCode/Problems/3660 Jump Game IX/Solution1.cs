namespace LeetCode.Problems._3660_Jump_Game_IX;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-464/problems/jump-game-ix/submissions/1746099881/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MaxValue(int[] nums)
    {
        var n = nums.Length;
        const int unset = -1;
        var ans = new int[n];
        Array.Fill(ans, unset);

        var pq = new PriorityQueue<int, (int inverseValue, int inverseIndex)>();
        for (var i = 0; i < n; i++)
        {
            pq.Enqueue(i, (-nums[i], -i));
        }

        var lastSetIndex = n;
        var minToTheRight = int.MaxValue;
        var lastMaxValue = int.MinValue;
        while (pq.Count > 0)
        {
            var i = pq.Dequeue();
            if (ans[i] != unset)
            {
                continue;
            }

            if (nums[i] <= minToTheRight)
            {
                lastMaxValue = nums[i];
                minToTheRight = int.MaxValue;
            }

            for (var j = i; j < lastSetIndex; j++)
            {
                ans[j] = lastMaxValue;
                minToTheRight = Math.Min(minToTheRight, nums[j]);
            }
            lastSetIndex = i;
        }

        return ans;
    }
}