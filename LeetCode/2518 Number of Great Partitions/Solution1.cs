using JetBrains.Annotations;

namespace LeetCode._2518_Number_of_Great_Partitions;

/// <summary>
/// https://leetcode.com/submissions/detail/866036157/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPartitions(int[] nums, int k)
    {
        var sum = nums.Select(num => (long) num).Sum();

        var minSum = k;
        var maxSum = sum - k;

        if (minSum > maxSum)
        {
            return 0;
        }

        if (nums.Max() > maxSum)
        {
            return 0;
        }

        const int modulo = 1_000_000_007;

        var totalPartitionsCount = 1;

        for (var i = 0; i < nums.Length; i++)
        {
            totalPartitionsCount = totalPartitionsCount * 2 % modulo;
        }

        var countsOfSmallPartitions = new int[k];
        countsOfSmallPartitions[0] = 1;

        foreach (var num in nums)
        {
            for (var i = k - 1 - num; i >= 0; i--)
            {
                countsOfSmallPartitions[i + num] =
                    (countsOfSmallPartitions[i + num] + countsOfSmallPartitions[i]) % modulo;
            }
        }

        var partitionCount = totalPartitionsCount;

        for (var i = 0; i < k; i++)
        {
            partitionCount = (partitionCount - 2 * countsOfSmallPartitions[i]) % modulo;

            if (partitionCount < 0)
            {
                partitionCount += modulo;
            }
        }

        return partitionCount;
    }
}
