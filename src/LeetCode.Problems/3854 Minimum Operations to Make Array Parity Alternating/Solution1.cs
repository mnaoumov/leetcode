namespace LeetCode.Problems._3854_Minimum_Operations_to_Make_Array_Parity_Alternating;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-177/problems/minimum-operations-to-make-array-parity-alternating/submissions/1933810711/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] MakeParityAlternating(int[] nums)
    {
        var numsMatchingParityByInitialParity = new[]
        {
            new List<int>(),
            new List<int>(),
        };

        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            var parity = Math.Abs(num) & 1;
            var indexParity = i & 1;
            numsMatchingParityByInitialParity[parity ^ indexParity].Add(num);
        }

        var minOperationsCount = Math.Min(numsMatchingParityByInitialParity[0].Count, numsMatchingParityByInitialParity[1].Count);

        var diff = int.MaxValue;

        if (minOperationsCount == 0)
        {
            diff = nums.Max() - nums.Min();
        }
        else
        {
            for (var initialParity = 0; initialParity <= 1; initialParity++)
            {
                if (numsMatchingParityByInitialParity[initialParity ^ 1].Count != minOperationsCount)
                {
                    continue;
                }

                var minFixed = numsMatchingParityByInitialParity[initialParity].Min();
                var maxFixed = numsMatchingParityByInitialParity[initialParity].Max();

                var minUnfixed = numsMatchingParityByInitialParity[initialParity ^ 1].Min();
                var maxUnfixed = numsMatchingParityByInitialParity[initialParity ^ 1].Max();

                var diffForParity = int.MaxValue;

                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var deltaMin in new[] { -1, 1 })
                {
                    // ReSharper disable once LoopCanBeConvertedToQuery
                    foreach (var deltaMax in new[] { -1, 1 })
                    {
                        var max = Math.Max(maxFixed, maxUnfixed + deltaMax);
                        var min = Math.Min(minFixed, minUnfixed + deltaMin);
                        diffForParity = Math.Min(diffForParity, Math.Abs(max - min));
                    }
                }

                diff = Math.Min(diff, diffForParity);
            }
        }

        return new[] { minOperationsCount, diff };
    }
}
