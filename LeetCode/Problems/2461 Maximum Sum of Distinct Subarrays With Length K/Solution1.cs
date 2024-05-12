using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable
#pragma warning disable IDE0059
#pragma warning disable CS0219

namespace LeetCode._2461_Maximum_Sum_of_Distinct_Subarrays_With_Length_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-318/submissions/detail/837734210/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        var items = new HashSet<int>();
        long result = 0;
        long sum = 0;

        var countDict = new Dictionary<int, int>();
        var set = new HashSet<int>();

        var index = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (i >= k)
            {
                var old = nums[i - k];
                countDict[old]--;

                if (countDict[old] == 0)
                {
                    set.Remove(old);
                }

                sum -= old;
            }

            var num = nums[i];

            if (!countDict.ContainsKey(num))
            {
                countDict[num] = 0;
            }

            countDict[num]++;
            set.Add(num);
            sum += num;

            if (set.Count == k)
            {
                result = Math.Max(result, sum);
            }
        }

        return result;
    }
}
