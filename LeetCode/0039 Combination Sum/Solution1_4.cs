// ReSharper disable All
using JetBrains.Annotations;

namespace LeetCode._0039_Combination_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/193999858/
/// https://leetcode.com/submissions/detail/195069394/
/// </summary>
[UsedImplicitly]
public class Solution1_4 : ISolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        if (target < 0)
            return new IList<int>[0];

        if (target == 0)
            return new IList<int>[] { new int[0] };

        List<IList<int>> result = new List<IList<int>>();
        foreach (var candidate in candidates)
        {
            var candidatesStartingFromCurrent = candidates.SkipWhile(c => c != candidate).ToArray();
            var targetAfterTakingCurrentCandidate = target - candidate;
            var resultsAfterTakingCurrentCandidate = CombinationSum(candidatesStartingFromCurrent, targetAfterTakingCurrentCandidate);
            result.AddRange(resultsAfterTakingCurrentCandidate.Select(newResult => new[] { candidate }.Concat(newResult).ToArray()));
        }

        return result;
    }
}