using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0039_Combination_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/195822588/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        return CombinationSum(candidates, target, 0);
    }

    private IList<IList<int>> CombinationSum(int[] candidates, int target, int startCandidateIndex)
    {
        if (target < 0)
        {
            return new List<IList<int>>();
        }

        if (target == 0)
        {
            return new List<IList<int>> { new List<int>() };
        }

        var combinationSums = new List<IList<int>>();

        for (int candidateIndex = startCandidateIndex; candidateIndex < candidates.Length; candidateIndex++)
        {
            var candidate = candidates[candidateIndex];
            var subTaskTarget = target - candidate;
            var subTaskCombinationSums = CombinationSum(candidates, subTaskTarget, candidateIndex);
            foreach (var subTaskCombinationSum in subTaskCombinationSums)
            {
                subTaskCombinationSum.Insert(0, candidate);
                combinationSums.Add(subTaskCombinationSum);
            }
        }

        return combinationSums;
    }
}
