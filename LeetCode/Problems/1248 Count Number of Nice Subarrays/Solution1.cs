namespace LeetCode.Problems._1248_Count_Number_of_Nice_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/856489076/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfSubarrays(int[] nums, int k)
    {
        var subarrayCounts = new Dictionary<int, int>
        {
            [0] = 1
        };

        var oddsCount = 0;
        var result = 0;

        foreach (var num in nums)
        {
            oddsCount += num % 2;
            result += subarrayCounts.GetValueOrDefault(oddsCount - k);
            subarrayCounts[oddsCount] = subarrayCounts.GetValueOrDefault(oddsCount) + 1;
        }

        return result;
    }
}
