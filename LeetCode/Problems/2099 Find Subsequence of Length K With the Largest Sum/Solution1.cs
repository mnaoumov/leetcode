namespace LeetCode.Problems._2099_Find_Subsequence_of_Length_K_With_the_Largest_Sum;

/// <summary>
/// https://leetcode.com/problems/find-subsequence-of-length-k-with-the-largest-sum/submissions/1678793945/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        var topCounts = nums.OrderByDescending(x => x).Take(k).GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        var ans = new int[k];

        var index = 0;

        foreach (var num in nums)
        {
            if (!topCounts.ContainsKey(num))
            {
                continue;
            }

            ans[index] = num;
            index++;
            topCounts[num]--;
            if (topCounts[num] == 0)
            {
                topCounts.Remove(num);
            }
        }

        return ans;
    }
}
