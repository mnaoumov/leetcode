namespace LeetCode._0039_Combination_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/813829281/
/// </summary>
public class Solution : ISolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        return CombinationSum(candidates, target, 0).ToArray();
    }

    private static IEnumerable<IList<int>> CombinationSum(IReadOnlyList<int> candidates, int target, int index)
    {
        if (target < 0)
        {
            yield break;
        }

        if (target == 0)
        {
            yield return Array.Empty<int>();
            yield break;
        }

        for (var i = index; i < candidates.Count; i++)
        {
            var candidate = candidates[i];

            foreach (var combinationRest in CombinationSum(candidates, target - candidate, i))
            {
                yield return new[] { candidate }.Concat(combinationRest).ToArray();
            }
        }
    }
}