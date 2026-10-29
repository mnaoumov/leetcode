namespace LeetCode.Problems._2163_Minimum_Difference_in_Sums_After_Removal_of_Elements;

/// <summary>
/// https://leetcode.com/problems/minimum-difference-in-sums-after-removal-of-elements/submissions/1702948134/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinimumDifference(int[] nums)
    {
        var m = nums.Length;
        var n = m / 3;
        var minSumsEndingAtIndex = new long[m];
        var maxSumsStartingAtIndex = new long[m];

        var pq = new PriorityQueue<int, int>();
        var sum = 0L;

        for (var i = 0; i < 2 * n; i++)
        {
            var num = nums[i];
            pq.Enqueue(num, -num);
            sum += num;

            if (i > n - 1)
            {
                sum -= pq.Dequeue();
            }

            minSumsEndingAtIndex[i] = sum;
        }

        pq.Clear();
        sum = 0L;

        for (var j = m - 1; j >= n; j--)
        {
            var num = nums[j];
            pq.Enqueue(num, num);
            sum += num;

            if (j < 2 * n)
            {
                sum -= pq.Dequeue();
            }

            maxSumsStartingAtIndex[j] = sum;
        }

        var ans = long.MaxValue;

        for (var i = n - 1; i <= 2 * n - 1; i++)
        {
            ans = Math.Min(ans, minSumsEndingAtIndex[i] - maxSumsStartingAtIndex[i + 1]);
        }

        return ans;
    }
}
