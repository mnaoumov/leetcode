using JetBrains.Annotations;

namespace LeetCode.Problems._3084_Count_Substrings_Starting_and_Ending_with_Given_Character;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-389/submissions/detail/1205842463/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountSubstrings(string s, char c)
    {
        var count = s.Count(letter => letter == c);
        return 1L * count * (count + 1) / 2;
    }
}
