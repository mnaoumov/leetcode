using JetBrains.Annotations;

namespace LeetCode.Problems._0491_Non_decreasing_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/919050278/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        var result = new List<IList<int>>();
        var subsequence = new List<int>();
        Backtrack(0);
        return result;

        void Backtrack(int i)
        {
            if (i > nums.Length)
            {
                return;
            }

            if (subsequence.Count >= 2)
            {
                result.Add(subsequence.ToArray());
            }

            var processedNums = new HashSet<int>();

            for (var j = i; j < nums.Length; j++)
            {
                if (subsequence.Count > 0 && subsequence[^1] > nums[j])
                {
                    continue;
                }

                if (!processedNums.Add(nums[j]))
                {
                    continue;
                }

                subsequence.Add(nums[j]);
                Backtrack(j + 1);
                subsequence.RemoveAt(subsequence.Count - 1);
            }
        }
    }
}
