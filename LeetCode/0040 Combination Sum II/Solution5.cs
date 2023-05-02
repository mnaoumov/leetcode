using JetBrains.Annotations;

namespace LeetCode._0040_Combination_Sum_II;

/// <summary>
/// https://leetcode.com/submissions/detail/829020371/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var candidatesWithCounts = candidates
            .OrderBy(x => x)
            .GroupBy(x => x)
            .Select(g => (value: g.Key, count: g.Count()))
            .ToArray();
        return CombinationSum(candidatesWithCounts, target, 0).ToArray();
    }

    private static IEnumerable<IList<int>> CombinationSum(IReadOnlyList<(int value, int count)> candidatesWithCounts, int target, int index)
    {
        if (target == 0)
        {
            yield return Array.Empty<int>();
            yield break;
        }

        if (target < 0 || index >= candidatesWithCounts.Count)
        {
            yield break;
        }

        if (candidatesWithCounts.Skip(index).Select(p => p.value * p.count).Sum() < target)
        {
            yield break;
        }

        for (var i = index; i < candidatesWithCounts.Count; i++)
        {
            var (candidate, count) = candidatesWithCounts[i];

            for (var j = 1; j <= count; j++)
            {
                foreach (var combinationRest in CombinationSum(candidatesWithCounts, target - candidate * j, i + 1))
                {
                    yield return Enumerable.Repeat(candidate, j).Concat(combinationRest).OrderBy(x => x).ToArray();
                }
            }
        }
    }
}
