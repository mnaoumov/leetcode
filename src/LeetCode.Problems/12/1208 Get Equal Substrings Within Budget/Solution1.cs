namespace LeetCode.Problems._1208_Get_Equal_Substrings_Within_Budget;

/// <summary>
/// https://leetcode.com/submissions/detail/898918285/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EqualSubstring(string s, string t, int maxCost)
    {
        var i = 0;
        var j = 0;

        var n = s.Length;
        var cost = 0;
        var result = 0;

        while (i < n)
        {
            while (j < n)
            {
                var nextCost = cost + Math.Abs(s[j] - t[j]);

                if (nextCost > maxCost)
                {
                    break;
                }

                cost = nextCost;
                j++;
                result = Math.Max(result, j - i);
            }

            cost -= Math.Abs(s[i] - t[i]);
            i++;
        }

        return result;
    }
}
