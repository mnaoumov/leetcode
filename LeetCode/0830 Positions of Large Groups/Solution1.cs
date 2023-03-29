using JetBrains.Annotations;

namespace LeetCode._0830_Positions_of_Large_Groups;

/// <summary>
/// https://leetcode.com/submissions/detail/924475661/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> LargeGroupPositions(string s)
    {
        var start = -1;
        var result = new List<IList<int>>();

        char lastLetter = default;

        for (var i = 0; i <= s.Length; i++)
        {
            if (i < s.Length && s[i] == lastLetter)
            {
                continue;
            }

            var end = i - 1;
            var length = end - start + 1;

            if (length >= 3)
            {
                result.Add(new[] { start, end });
            }

            if (i == s.Length)
            {
                continue;
            }

            start = i;
            lastLetter = s[i];
        }

        return result;
    }
}
