namespace LeetCode.Problems._2736_Maximum_Sum_Queries;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-349/submissions/detail/968572750/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] MaximumSumQueries(int[] nums1, int[] nums2, int[][] queries)
    {
        var n = nums1.Length;
        var m = queries.Length;
        var ans = new int[m];

        var sums = nums1.Zip(nums2, (num1, num2) => num1 + num2).ToArray();

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var x = query[0];
            var y = query[1];
            var max = Enumerable.Range(0, n).Where(j => nums1[j] >= x && nums2[j] >= y).Select(j => sums[j]).Prepend(-1)
                .Max();
            ans[i] = max;
        }

        return ans;
    }
}
