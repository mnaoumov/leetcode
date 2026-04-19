namespace LeetCode.Problems._0755_Pour_Water;

/// <summary>
/// https://leetcode.com/problems/pour-water/submissions/1972134924/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int[] PourWater(int[] heights, int volume, int k)
    {
        var ans = heights.ToArray();

        var n = heights.Length;

        for (var i = 0; i < volume; i++)
        {
            var j = k;
            var level = ans[k];

            while (true)
            {
                while (j > 0 && ans[j - 1] <= ans[j])
                {
                    j--;
                }

                while (j < n - 1 && ans[j + 1] <= ans[j])
                {
                    j++;
                }

                if (ans[j] == level)
                {
                    break;
                }

                level = ans[j];
            }

            if (level == ans[k])
            {
                j = k;
            }

            ans[j]++;
        }

        return ans;
    }
}
