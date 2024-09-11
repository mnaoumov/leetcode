namespace LeetCode.Problems._0161_One_Edit_Distance;

/// <summary>
/// https://leetcode.com/submissions/detail/870815679/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    public bool IsOneEditDistance(string s, string t)
    {
        if (Math.Abs(s.Length - t.Length) > 1)
        {
            return false;
        }

        if (s == t)
        {
            return false;
        }

        if (s == "" || t == "")
        {
            return true;
        }

        var index = 0;

        while (s[index] == t[index])
        {
            index++;
        }

        var tailLength = Math.Min(s.Length, t.Length) - index;

        if (s.Length == t.Length)
        {
            tailLength--;
        }

        return s[^tailLength..] == t[^tailLength..];
    }
}
