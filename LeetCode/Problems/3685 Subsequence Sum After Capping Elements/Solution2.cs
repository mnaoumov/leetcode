namespace LeetCode.Problems._3685_Subsequence_Sum_After_Capping_Elements;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-467/problems/subsequence-sum-after-capping-elements/submissions/1770003874/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
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

            var subsequenceSums = new HashSet<int>();
            subsequenceSums.Add(0);

            foreach (var num in nums)
            {
                foreach (var sum in subsequenceSums.ToArray())
                {
                    var cap = Math.Min(i + 1, num);

                    if (sum + cap == k)
                    {
                        ans[i] = true;
                        break;
                    }

                    subsequenceSums.Add(sum + cap);
                }

                if (ans[i])
                {
                    break;
                }
            }
        }

        return ans;
    }
}
