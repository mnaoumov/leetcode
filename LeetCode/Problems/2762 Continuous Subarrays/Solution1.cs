using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2762_Continuous_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-352/submissions/detail/984244061/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long ContinuousSubarrays(int[] nums)
    {
        var minIndices = new LinkedList<int>();
        var maxIndices = new LinkedList<int>();

        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            while (minIndices.Count > 0 && nums[minIndices.Last!.Value] > num)
            {
                minIndices.RemoveLast();
            }

            minIndices.AddLast(i);

            while (maxIndices.Count > 0 && nums[maxIndices.Last!.Value] < num)
            {
                maxIndices.RemoveLast();
            }

            maxIndices.AddLast(i);

            while (nums[maxIndices.First!.Value] > num + 2)
            {
                maxIndices.RemoveFirst();
            }

            while (nums[minIndices.First!.Value] < num - 2)
            {
                minIndices.RemoveFirst();
            }

            ans += i + 1 - Math.Min(minIndices.First.Value, maxIndices.First.Value);
        }

        return ans;
    }
}
