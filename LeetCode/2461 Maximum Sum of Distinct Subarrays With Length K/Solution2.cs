using JetBrains.Annotations;

namespace LeetCode._2461_Maximum_Sum_of_Distinct_Subarrays_With_Length_K;

/// <summary>
/// https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/submissions/838923936/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        long result = 0;
        long sum = 0;

        var countDict = new Dictionary<int, int>();
        var set = new HashSet<int>();

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
