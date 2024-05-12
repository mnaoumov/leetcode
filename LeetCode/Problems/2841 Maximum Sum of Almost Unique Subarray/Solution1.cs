using JetBrains.Annotations;

namespace LeetCode.Problems._2841_Maximum_Sum_of_Almost_Unique_Subarray;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-112/submissions/detail/1038538797/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxSum(IList<int> nums, int m, int k)
    {
        if (nums.Count < k)
        {
            return 0;
        }

        var ans = 0L;
        var sum = 0L;
        var counts = new Dictionary<int, int>();

        for (var i = 0; i < nums.Count; i++)
        {
            if (i >= k)
            {
                var oldNum = nums[i - k];
                counts[oldNum]--;

                if (counts[oldNum] == 0)
                {
                    counts.Remove(oldNum);
                }

                sum -= oldNum;
            }

            var num = nums[i];
            counts.TryAdd(num, 0);
            counts[num]++;
            sum += num;

            if (counts.Count >= m)
            {
                ans = Math.Max(ans, sum);
            }
        }

        return ans;
    }
}
