namespace LeetCode.Problems._0455_Assign_Cookies;

/// <summary>
/// https://leetcode.com/submissions/detail/914085070/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        var cookieIndex = 0;

        var result = 0;

        foreach (var greed in g)
        {
            while (cookieIndex < s.Length && s[cookieIndex] < greed)
            {
                cookieIndex++;
            }

            if (cookieIndex == s.Length)
            {
                break;
            }

            result++;
            cookieIndex++;
        }

        return result;
    }
}
