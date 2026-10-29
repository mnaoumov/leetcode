namespace LeetCode.Problems._2966_Divide_Array_Into_Arrays_With_Max_Difference;

/// <summary>
/// https://leetcode.com/submissions/detail/1121514268/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[][] DivideArray(int[] nums, int k)
    {
        Array.Sort(nums);

        var n = nums.Length;
        var m = n / 3;

        var ans = Enumerable.Range(0, m)
            .Select(i => Enumerable.Range(0, 3).Select(j => nums[3 * i + j]).ToArray())
            .ToArray();

        for (var i = 0; i < m; i++)
        {
            if (ans[i][2] - ans[i][0] > k)
            {
                return Array.Empty<int[]>();
            }
        }

        return ans;
    }
}
