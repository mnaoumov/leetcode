using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2495_Number_of_Subarrays_Having_Even_Product;

/// <summary>
/// https://leetcode.com/submissions/detail/870021681/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long EvenProduct(int[] nums)
    {
        long result = 0;

        var n = nums.Length;
        var indexOfLastEvenNumber = -1;
        for (var i = 0; i < n; i++)
        {
            if (nums[i] % 2 != 0)
            {
                continue;
            }

            result += (n - i) * (i - indexOfLastEvenNumber);
            indexOfLastEvenNumber = i;
        }

        return result;
    }
}
