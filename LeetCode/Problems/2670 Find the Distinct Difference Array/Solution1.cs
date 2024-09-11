namespace LeetCode.Problems._2670_Find_the_Distinct_Difference_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-344/submissions/detail/945794380/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] DistinctDifferenceArray(int[] nums)
    {
        var n  = nums.Length;
        var ans = new int[n];

        var prefixSet = new HashSet<int>();
        var suffixCounts = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            suffixCounts[num] = suffixCounts.GetValueOrDefault(num) + 1;
        }

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            prefixSet.Add(num);
            suffixCounts[num]--;

            if (suffixCounts[num] == 0)
            {
                suffixCounts.Remove(num);
            }

            ans[i] = prefixSet.Count - suffixCounts.Count;
        }

        return ans;
    }
}
