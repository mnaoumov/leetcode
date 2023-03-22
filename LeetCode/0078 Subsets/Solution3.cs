using JetBrains.Annotations;

namespace LeetCode._0078_Subsets;

/// <summary>
/// https://leetcode.com/submissions/detail/918818613/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        var subset = new List<int>();
        Backtrack(0);
        return result;

        void Backtrack(int i)
        {
            if (i > nums.Length)
            {
                return;
            }

            result.Add(subset.ToArray());

            for (var j = i; j < nums.Length; j++)
            {
                subset.Add(nums[j]);
                Backtrack(j + 1);
                subset.RemoveAt(subset.Count - 1);
            }
        }
    }
}