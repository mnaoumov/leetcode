using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0416_Partition_Equal_Subset_Sum;

/// <summary>
/// 
/// </summary>
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanPartition(int[] nums)
    {
        var sum = nums.Sum();
        if (sum % 2 != 0)
        {
            return false;
        }

        var targetSum = sum / 2;

        var possibleSums = new List<int> { 0 };

        foreach (var num in nums)
        {
            foreach (var possibleSum in possibleSums.ToArray())
            {
                var nextPossibleSum = possibleSum + num;
                if (nextPossibleSum == targetSum)
                {
                    return true;
                }

                possibleSums.Add(nextPossibleSum);
            }
        }


        return false;
    }
}
