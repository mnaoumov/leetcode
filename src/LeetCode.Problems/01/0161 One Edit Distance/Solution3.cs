namespace LeetCode.Problems._0161_One_Edit_Distance;

/// <summary>
/// https://leetcode.com/submissions/detail/870817922/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
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

        var minLength = Math.Min(s.Length, t.Length);
        var index = Enumerable.Range(0, minLength).FirstOrDefault(i => s[i] != t[i], minLength);

        var tailLength = minLength - index;

        if (s.Length == t.Length)
        {
            tailLength--;
        }

        return s[^tailLength..] == t[^tailLength..];
    }
}
