using JetBrains.Annotations;

namespace LeetCode._2459_Sort_Array_by_Moving_Items_to_Empty_Space;

/// <summary>
/// https://leetcode.com/submissions/detail/879020135/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int SortArray(int[] nums)
    {
        var n = nums.Length;
        var valueToIndexMap = new int[n];

        var wrongLeftSidedIndices = new HashSet<int>();
        var wrongRightSidedIndices = new HashSet<int>();

        for (var i = 0; i < n; i++)
        {
            valueToIndexMap[nums[i]] = i;

            if (nums[i] == 0)
            {
                continue;
            }

            if (nums[i] != i)
            {
                wrongLeftSidedIndices.Add(i);
            }

            if (nums[i] != i + 1)
            {
                wrongRightSidedIndices.Add(i);
            }
        }

        return Math.Min(wrongLeftSidedIndices.Count, wrongRightSidedIndices.Count);
    }
}
