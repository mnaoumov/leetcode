namespace LeetCode.Problems._0389_Find_the_Difference;

/// <summary>
/// https://leetcode.com/submissions/detail/927557820/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public char FindTheDifference(string s, string t)
    {
        var sCounts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        var tCounts = t.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        foreach (var (letter, tCount) in tCounts)
        {
            if (sCounts.GetValueOrDefault(letter) == tCount - 1)
            {
                return letter;
            }
        }

        return default;
    }
}
