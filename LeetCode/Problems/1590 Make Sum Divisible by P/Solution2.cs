namespace LeetCode.Problems._1590_Make_Sum_Divisible_by_P;

/// <summary>
/// https://leetcode.com/submissions/detail/1410677039/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinSubarray(int[] nums, int p)
    {
        var n = nums.Length;
        var prefixSumsRemainders = new int[n + 1];
        for (var i = 0; i < n; i++)
        {
            prefixSumsRemainders[i + 1] = (prefixSumsRemainders[i] + nums[i]) % p;
        }

        var subarraySumRemainderToRemove = prefixSumsRemainders[n];
        if (subarraySumRemainderToRemove == 0)
        {
            return 0;
        }

        var lastRemainderIndices = new Dictionary<int, int>
        {
            [0] = 0
        };

        var ans = int.MaxValue;

        for (var j = 1; j <= n; j++)
        {
            lastRemainderIndices[prefixSumsRemainders[j]] = j;
            var startSumReminderToRemove = (prefixSumsRemainders[j] - subarraySumRemainderToRemove + p) % p;
            if (lastRemainderIndices.TryGetValue(startSumReminderToRemove, out var i))
            {
                ans = Math.Min(ans, j - i);
            }
        }

        return ans == n ? -1 : ans;
    }
}
