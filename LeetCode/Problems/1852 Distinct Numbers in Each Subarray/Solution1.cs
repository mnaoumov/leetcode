namespace LeetCode.Problems._1852_Distinct_Numbers_in_Each_Subarray;

/// <summary>
/// https://leetcode.com/problems/distinct-numbers-in-each-subarray/submissions/1526893591/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] DistinctNumbers(int[] nums, int k)
    {
        var n = nums.Length;
        var ans = new int[n - k + 1];
        var counts = new Dictionary<int, int>();
        for (var i = 0; i < k; i++)
        {
            var num = nums[i];
            counts.TryAdd(num, 0);
            counts[num]++;
        }
        ans[0] = counts.Count;

        for (var i = 1; i < n - k + 1; i++)
        {
            var num = nums[i - 1];
            counts[num]--;
            if (counts[num] == 0)
            {
                counts.Remove(num);
            }
            num = nums[i + k - 1];
            counts.TryAdd(num, 0);
            counts[num]++;
            ans[i] = counts.Count;
        }

        return ans;
    }
}
