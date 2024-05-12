using JetBrains.Annotations;

namespace LeetCode.Problems._2799_Count_Complete_Subarrays_in_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-356/submissions/detail/1007327254/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountCompleteSubarrays(int[] nums)
    {
        var distinctCount = nums.Distinct().Count();

        var i = 0;

        var counts = new Dictionary<int, int>();

        var ans = 0;

        var n = nums.Length;

        for (var j = 0; j < n; j++)
        {
            var num = nums[j];
            counts.TryAdd(num, 0);
            counts[num]++;

            while (counts.Count == distinctCount)
            {
                ans += n - j;
                var oldNum = nums[i];
                counts[oldNum]--;

                if (counts[oldNum] == 0)
                {
                    counts.Remove(oldNum);
                }

                i++;
            }
        }

        return ans;
    }
}
