namespace LeetCode.Problems._2028_Find_Missing_Observations;

/// <summary>
/// https://leetcode.com/submissions/detail/1380510109/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        var m = rolls.Length;
        var mSum = rolls.Sum();
        var totalSum = mean * (m + n);
        var nSum = totalSum - mSum;
        if (nSum < n || nSum > 6 * n)
        {
            return Array.Empty<int>();
        }

        var k = (nSum - n) / 5;
        var r = (nSum - n) % 5;
        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            if (i < k)
            {
                ans[i] = 6;
            }
            else if (i == k)
            {
                ans[i] = 1 + r;
            }
            else
            {
                ans[i] = 1;
            }
        }

        return ans;
    }
}
