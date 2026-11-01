
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0416_Partition_Equal_Subset_Sum;

/// <seealso href="https://leetcode.com/submissions/detail/196671577/">Submission</seealso>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool CanPartition(int[] nums)
    {
        var sum = nums.Sum();
        if (sum % 2 != 0)
        {
            return false;
        }

        var targetSum = sum / 2;

        var possibleSums = new HashSet<int> { 0 };

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
