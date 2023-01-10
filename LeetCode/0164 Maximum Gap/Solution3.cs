using JetBrains.Annotations;

namespace LeetCode._0164_Maximum_Gap;

/// <summary>
/// https://leetcode.com/submissions/detail/874467905/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaximumGap(int[] nums)
    {
        var n = nums.Length;

        if (n < 2)
        {
            return 0;
        }

        var min = nums.Min();
        var max = nums.Max();
        var bucketSize = Math.Max(1, (max - min) / (n - 1));

        var bucketCount = (max - min) / bucketSize + 1;

        var bucketMins = Enumerable.Repeat(int.MaxValue, bucketCount).ToArray();
        var bucketMaxes = Enumerable.Repeat(int.MinValue, bucketCount).ToArray();

        foreach (var num in nums)
        {
            var bucketIndex = (num - min) / bucketSize;
            bucketMins[bucketIndex] = Math.Min(bucketMins[bucketIndex], num);
            bucketMaxes[bucketIndex] = Math.Max(bucketMaxes[bucketIndex], num);
        }

        var lastNonEmptyBucketIndex = -1;

        var result = 0;

        for (var i = 0; i < bucketCount; i++)
        {
            if (bucketMins[i] == int.MaxValue)
            {
                continue;
            }

            if (lastNonEmptyBucketIndex != -1)
            {
                result = Math.Max(result, bucketMins[i] - bucketMaxes[lastNonEmptyBucketIndex]);
            }

            lastNonEmptyBucketIndex = i;
        }

        return result;
    }
}
