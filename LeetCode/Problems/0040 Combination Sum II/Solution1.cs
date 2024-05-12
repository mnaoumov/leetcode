using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0040_Combination_Sum_II;

/// <summary>
/// https://leetcode.com/submissions/detail/813865539/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        return CombinationSum(candidates, target, 0).ToArray();
    }

    private static IEnumerable<IList<int>> CombinationSum(IReadOnlyList<int> candidates, int target, int index)
    {
        if (target == 0)
        {
            yield return Array.Empty<int>();
            yield break;
        }

        if (target < 0 || index >= candidates.Count)
        {
            yield break;
        }

        var keys = new HashSet<string>();


        for (var i = index; i < candidates.Count; i++)
        {
            var candidate = candidates[i];

            foreach (var combinationRest in CombinationSum(candidates, target - candidate, i + 1))
            {
                var combination = new[] { candidate }.Concat(combinationRest).OrderBy(x => x).ToArray();

                var key = string.Join(",", combination);

                if (keys.Add(key))
                {
                    yield return combination;
                }
            }
        }
    }
}
