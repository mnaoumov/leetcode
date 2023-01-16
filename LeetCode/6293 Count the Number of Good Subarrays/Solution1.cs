using JetBrains.Annotations;

namespace LeetCode._6293_Count_the_Number_of_Good_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-328/submissions/detail/878353370/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountGood(int[] nums, int k)
    {
        var countsMap = new Dictionary<int, int>();
        var pairsCount = 0;

        var result = 0L;

        var n = nums.Length;
        var startIndex = 0;

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            countsMap[num] = countsMap.GetValueOrDefault(num) + 1;
            pairsCount += countsMap[num] - 1;

            while (pairsCount >= k)
            {
                result += n - i;
                var startingNum = nums[startIndex];
                startIndex++;
                countsMap[startingNum]--;
                pairsCount -= countsMap[startingNum];
            }
        }

        return result;
    }
}
