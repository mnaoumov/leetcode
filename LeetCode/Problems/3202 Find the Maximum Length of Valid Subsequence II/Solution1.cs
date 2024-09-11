using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3202_Find_the_Maximum_Length_of_Valid_Subsequence_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-404/submissions/detail/1304426692/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaximumLength(int[] nums, int k)
    {
        var modIndices = Enumerable.Range(0, k).Select(_ => new List<int>()).ToArray();

        for (var i = 0; i < nums.Length; i++)
        {
            var mod = nums[i] % k;
            modIndices[mod].Add(i);
        }

        var ans = modIndices.Max(indices => indices.Count);

        for (var mod1 = 0; mod1 < k; mod1++)
        {
            for (var mod2 = 0; mod2 < k; mod2++)
            {
                if (mod1 == mod2 || modIndices[mod1].Count + modIndices[mod2].Count <= ans)
                {
                    continue;
                }

                var lastSequenceItemIndex = -1;
                var sequenceLength = 0;

                var mods = new[] { mod1, mod2 };

                var isDone = false;

                while (true)
                {
                    foreach (var mod in mods)
                    {
                        var indexOfIndex = modIndices[mod].BinarySearch(lastSequenceItemIndex + 1);

                        if (indexOfIndex < 0)
                        {
                            isDone = true;
                            break;
                        }

                        lastSequenceItemIndex = modIndices[mod][indexOfIndex];
                        sequenceLength++;
                    }

                    if (isDone)
                    {
                        break;
                    }
                }

                ans = Math.Max(ans, sequenceLength);
            }
        }

        return ans;
    }
}
