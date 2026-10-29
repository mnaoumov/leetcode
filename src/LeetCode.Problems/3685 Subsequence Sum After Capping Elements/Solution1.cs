namespace LeetCode.Problems._3685_Subsequence_Sum_After_Capping_Elements;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-467/problems/subsequence-sum-after-capping-elements/submissions/1769984246/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool[] SubsequenceSumAfterCapping(int[] nums, int k)
    {
        var n = nums.Length;
        var ans = new bool[n];

        for (var i = 0; i < n; i++)
        {
            if ((i + 1) * n < k)
            {
                continue;
            }

            var prefixSums = new HashSet<int>();
            prefixSums.Add(0);
            var prefixSum = 0;

            foreach (var num in nums)
            {
                prefixSum += Math.Min(num, i + 1);

                if (prefixSums.Contains(prefixSum - k))
                {
                    ans[i] = true;
                    break;
                }

                prefixSums.Add(prefixSum);
            }
        }

        return ans;
    }
}
