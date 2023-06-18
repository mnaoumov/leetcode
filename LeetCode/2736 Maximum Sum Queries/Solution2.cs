using JetBrains.Annotations;

namespace LeetCode._2736_Maximum_Sum_Queries;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] MaximumSumQueries(int[] nums1, int[] nums2, int[][] queries)
    {
        var n = nums1.Length;
        var m = queries.Length;
        var ans = new int[m];

        var sums = nums1.Zip(nums2, (num1, num2) => num1 + num2).ToArray();

        var pairs = Enumerable.Range(0, n).OrderBy(i => nums1[i]).ThenBy(i => nums2[i]).ToArray();

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
