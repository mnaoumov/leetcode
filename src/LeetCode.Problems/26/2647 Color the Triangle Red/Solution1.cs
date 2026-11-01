namespace LeetCode.Problems._2647_Color_the_Triangle_Red;

/// <seealso href="https://leetcode.com/submissions/detail/957270181/">Submission</seealso>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[][] ColorRed(int n)
    {
        var ans = new int[2 * n - 1][];

        ans[0] = new[] { 1, 1 };

        for (var i = 2; i <= n; i++)
        {
            ans[2 * i - 3] = new[] { i, 1 };
            ans[2 * i - 2] = new[] { i, 2 * i - 1 };
        }

        return ans;
    }
}
