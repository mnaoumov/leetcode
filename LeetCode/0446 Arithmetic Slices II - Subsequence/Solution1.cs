using JetBrains.Annotations;

namespace LeetCode._0446_Arithmetic_Slices_II___Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/850737813/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumberOfArithmeticSlices(int[] nums)
    {
        var numIndicesMap = nums.Select((num, index) => (num, index)).ToLookup(p => p.num, p => p.index)
            .ToDictionary(g => g.Key, g => g.OrderBy(x => x).ToArray());

        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                var diff = nums[j] - nums[i];

                result += GetCount(nums[j], diff, j + 1);
            }
        }

        return result;

        int GetCount(int num, int diff, int minIndex)
        {
            var nextNum = num + diff;

            if (!numIndicesMap.ContainsKey(nextNum))
            {
                return 0;
            }

            var indices = numIndicesMap[nextNum];

            var position = Array.BinarySearch(indices, minIndex);

            if (position < 0)
            {
                position = ~position;
            }

            return indices.Skip(position).Sum(index => 1 + GetCount(nextNum, diff, index + 1));
        }
    }
}
