using JetBrains.Annotations;

namespace LeetCode._2588_Count_the_Number_of_Beautiful_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-336/submissions/detail/913529921/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long BeautifulSubarrays(int[] nums)
    {
        var xor = 0;
        var xorCounts = new Dictionary<int, int> { [0] = 1 };
        var result = 0L;
        foreach (var num in nums)
        {
            xor ^= num;
            xorCounts[xor] = xorCounts.GetValueOrDefault(xor) + 1;
            result += xorCounts[xor] - 1;
        }

        return result;
    }
}
