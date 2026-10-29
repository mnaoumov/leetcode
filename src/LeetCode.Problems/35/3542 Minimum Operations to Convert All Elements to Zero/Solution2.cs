namespace LeetCode.Problems._3542_Minimum_Operations_to_Convert_All_Elements_to_Zero;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-156/problems/minimum-operations-to-convert-all-elements-to-zero/submissions/1630179866/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var n = nums.Length;
        var valueIndicesMap = new Dictionary<int, List<int>>();
        var zeroIndices = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            if (num == 0)
            {
                zeroIndices.Add(i);
                continue;
            }
            valueIndicesMap.TryAdd(num, new List<int>());
            valueIndicesMap[num].Add(i);
        }

        var ans = 0;

        foreach (var minValue in valueIndicesMap.Keys.OrderBy(x => x).ToArray())
        {
            var indices = valueIndicesMap[minValue];
            var previousIndexOfIndex = int.MinValue;

            foreach (var index in indices)
            {
                var indexOfIndex = ~zeroIndices.BinarySearch(index);
                if (indexOfIndex != previousIndexOfIndex + 1)
                {
                    ans++;
                }

                zeroIndices.Insert(indexOfIndex, index);
                previousIndexOfIndex = indexOfIndex;
            }
        }

        return ans;
    }
}
