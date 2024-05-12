using JetBrains.Annotations;

namespace LeetCode._2962_Count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-375/submissions/detail/1116145823/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountSubarrays(int[] nums, int k)
    {
        var n = nums.Length;
        var max = nums.Max();
        var maxIndices = Enumerable.Range(0, n).Where(i => nums[i] == max).ToArray();

        var ans = 0L;

        for (var i = 0; i <= maxIndices.Length - k; i++)
        {
            var previousMaxIndex = i == 0 ? -1 : maxIndices[i - 1];
            ans += 1L * (maxIndices[i] - previousMaxIndex) * (n - maxIndices[i + k - 1]);
        }

        return ans;
    }
}
