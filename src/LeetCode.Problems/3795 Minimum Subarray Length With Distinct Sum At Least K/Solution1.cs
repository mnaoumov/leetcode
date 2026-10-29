namespace LeetCode.Problems._3795_Minimum_Subarray_Length_With_Distinct_Sum_At_Least_K;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-173/problems/minimum-subarray-length-with-distinct-sum-at-least-k/submissions/1873210440/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinLength(int[] nums, int k)
    {
        var counts = new Dictionary<int, int>();
        var n = nums.Length;

        var startIndex = 0;
        var ans = int.MaxValue;
        var sum = 0;

        for (var endIndex = 0; endIndex < n; endIndex++)
        {
            var num = nums[endIndex];

            if (num >= k)
            {
                return 1;
            }

            counts.TryAdd(num, 0);
            counts[num]++;
            if (counts[num] == 1)
            {
                sum += num;
            }

            while (startIndex < endIndex)
            {
                if (sum < k)
                {
                    break;
                }

                ans = Math.Min(ans, endIndex - startIndex + 1);

                var oldNum = nums[startIndex];
                counts[oldNum]--;
                if (counts[oldNum] == 0)
                {
                    sum -= oldNum;
                }

                startIndex++;
            }
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}
