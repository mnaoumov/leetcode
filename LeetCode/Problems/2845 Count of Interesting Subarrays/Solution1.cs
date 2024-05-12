using JetBrains.Annotations;

namespace LeetCode.Problems._2845_Count_of_Interesting_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-361/submissions/detail/1039077169/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
    {
        var n = nums.Count;

        var prefixCounts = new int[n];
        var countsOfPrefixCounts = new Dictionary<int, int>();
        var filteredNumsCount = 0;

        for (var i = 0; i < n; i++)
        {
            if (nums[i] % modulo == k)
            {
                filteredNumsCount = (filteredNumsCount + 1) % modulo;
            }

            prefixCounts[i] = filteredNumsCount;
            countsOfPrefixCounts.TryAdd(filteredNumsCount, 0);
            countsOfPrefixCounts[filteredNumsCount]++;
        }

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            var previousPrefixSum = i == 0 ? 0 : prefixCounts[i - 1];
            var requiredPrefixSum = (k + previousPrefixSum) % modulo;
            ans += countsOfPrefixCounts.GetValueOrDefault(requiredPrefixSum);
            countsOfPrefixCounts[prefixCounts[i]]--;
        }

        return ans;
    }
}
