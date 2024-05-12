using JetBrains.Annotations;

namespace LeetCode.Problems._2966_Divide_Array_Into_Arrays_With_Max_Difference;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-376/submissions/detail/1121429618/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
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
            if (Enumerable.Range(0, 2).Any(j => ans[i][j + 1] - ans[i][j] > k))
            {
                return Array.Empty<int[]>();
            }
        }

        return ans;
    }
}
