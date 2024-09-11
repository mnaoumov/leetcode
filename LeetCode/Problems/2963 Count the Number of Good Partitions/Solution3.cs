using System.Numerics;

namespace LeetCode.Problems._2963_Count_the_Number_of_Good_Partitions;

/// <summary>
/// https://leetcode.com/submissions/detail/1116201512/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int NumberOfGoodPartitions(int[] nums)
    {
        var countsAfter = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var intersection = new HashSet<int>();

        var partitionIndicesCount = 0;

        foreach (var num in nums)
        {
            countsAfter[num]--;

            if (countsAfter[num] != 0)
            {
                intersection.Add(num);
            }
            else
            {
                intersection.Remove(num);

                if (intersection.Count == 0)
                {
                    partitionIndicesCount++;
                }
            }
        }

        const int modulo = 1_000_000_007;
        return (int) BigInteger.ModPow(2, partitionIndicesCount - 1, modulo);
    }
}
