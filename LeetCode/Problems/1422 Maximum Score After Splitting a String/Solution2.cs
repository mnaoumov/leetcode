namespace LeetCode.Problems._1422_Maximum_Score_After_Splitting_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1126098694/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxScore(string s)
    {
        var zerosCount = 0;
        var ans = int.MinValue;

        var n = s.Length;

        for (var i = 0; i < n; i++)
        {
            if (s[i] == '0')
            {
                zerosCount++;
            }

            if (i == n - 1)
            {
                break;
            }

            ans = Math.Max(ans, 2 * zerosCount - i);
        }

        ans += n - zerosCount - 1;

        return ans;
    }
}
