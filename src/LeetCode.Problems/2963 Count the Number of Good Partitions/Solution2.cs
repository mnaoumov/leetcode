using System.Numerics;

namespace LeetCode.Problems._2963_Count_the_Number_of_Good_Partitions;

/// <summary>
/// https://leetcode.com/submissions/detail/1116197537/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int NumberOfGoodPartitions(int[] nums)
    {
        var numsBefore = new HashSet<int>();
        var countsAfter = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var numsAfter = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count()).Keys.ToHashSet();

        var partitionIndicesCount = 0;

        var isPartitionIndex = true;

        foreach (var num in nums)
        {
            numsBefore.Add(num);
            countsAfter[num]--;

            if (countsAfter[num] != 0)
            {
                isPartitionIndex = false;
                continue;
            }

            numsAfter.Remove(num);
            isPartitionIndex = isPartitionIndex || !numsBefore.Overlaps(numsAfter);

            if (isPartitionIndex)
            {
                partitionIndicesCount++;
            }
        }

        const int modulo = 1_000_000_007;
        return (int) BigInteger.ModPow(2, partitionIndicesCount - 1, modulo);
    }
}
