namespace LeetCode.Problems._2364_Count_Number_of_Bad_Pairs;

/// <summary>
/// https://leetcode.com/problems/count-number-of-bad-pairs/submissions/1536346943/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountBadPairs(int[] nums)
    {
        var diffCounts = new Dictionary<int, int>();
        var ans = 0L;

        for (var i = 0; i < nums.Length; i++)
        {
            var diff = nums[i] - i;
            diffCounts.TryAdd(diff, 0);
            diffCounts[diff]++;
            ans += i + 1 - diffCounts[diff];
        }

        return ans;
    }
}
