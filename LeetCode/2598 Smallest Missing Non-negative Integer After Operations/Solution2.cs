using JetBrains.Annotations;

namespace LeetCode._2598_Smallest_Missing_Non_negative_Integer_After_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/918958820/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FindSmallestInteger(int[] nums, int value)
    {
        var remainderCounts = nums.Select(Remainder).GroupBy(remainder => remainder)
            .ToDictionary(g => g.Key, g => g.Count());

        var minCount = int.MaxValue;
        var remainderWithMinCount = int.MaxValue;

        for (var remainder = 0; remainder < value; remainder++)
        {
            var count = remainderCounts.GetValueOrDefault(remainder);

            if (count >= minCount)
            {
                continue;
            }

            minCount = count;
            remainderWithMinCount = remainder;
        }

        return minCount * value + remainderWithMinCount;

        int Remainder(int num)
        {
            return (num % value + value) % value;
        }
    }
}
