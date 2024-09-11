namespace LeetCode.Problems._2672_Number_of_Adjacent_Elements_With_the_Same_Color;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-344/submissions/detail/945820733/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ColorTheArray(int n, int[][] queries)
    {
        var nums = new int[n];
        var ans = new int[queries.Length];

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var index = query[0];
            var color = query[1];

            var oldColor = nums[index];
            nums[index] = color;

            if (i > 0)
            {
                ans[i] = ans[i - 1];
            }

            if (oldColor == color)
            {
                continue;
            }

            if (index > 0)
            {
                if (oldColor != 0 && nums[index - 1] == oldColor)
                {
                    ans[i]--;
                }

                if (nums[index - 1] == color)
                {
                    ans[i]++;
                }
            }

            if (index == n - 1)
            {
                continue;
            }

            if (oldColor != 0 && nums[index + 1] == oldColor)
            {
                ans[i]--;
            }

            if (nums[index + 1] == color)
            {
                ans[i]++;
            }
        }

        return ans;
    }
}
