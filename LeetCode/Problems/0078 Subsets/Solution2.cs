using JetBrains.Annotations;

namespace LeetCode.Problems._0078_Subsets;

/// <summary>
/// https://leetcode.com/submissions/detail/918813960/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        var subset = new List<int>();
        Backtrack(0);
        return result;

        void Backtrack(int i)
        {
            if (i == nums.Length)
            {
                result.Add(subset.ToArray());
                return;
            }

            Backtrack(i + 1);

            subset.Add(nums[i]);
            Backtrack(i + 1);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
