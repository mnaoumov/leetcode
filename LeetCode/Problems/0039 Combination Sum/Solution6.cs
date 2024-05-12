using JetBrains.Annotations;

namespace LeetCode.Problems._0039_Combination_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/918839797/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        var combination = new List<int>();
        var sum = 0;
        Backtrack(0);
        return result;

        void Backtrack(int i)
        {
            if (sum == target)
            {
                result.Add(combination.ToArray());
                return;
            }

            for (var j = i; j < candidates.Length; j++)
            {
                var candidate = candidates[j];

                if (sum + candidate > target)
                {
                    continue;
                }

                combination.Add(candidate);
                sum += candidate;
                Backtrack(j);
                combination.RemoveAt(combination.Count - 1);
                sum -= candidate;
            }
        }
    }
}
