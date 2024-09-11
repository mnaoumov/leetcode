namespace LeetCode.Problems._2598_Smallest_Missing_Non_negative_Integer_After_Operations;

/// <summary>
/// https://leetcode.com/problems/smallest-missing-non-negative-integer-after-operations/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
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

        return minCount * value + remainderWithMinCount + (remainderWithMinCount == 0 ? value : 0);

        int Remainder(int num)
        {
            return (num % value + value) % value;
        }
    }
}
