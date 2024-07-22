using JetBrains.Annotations;

namespace LeetCode.Problems._3227_Vowels_Game_in_a_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-407/submissions/detail/1327912423/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool DoesAliceWin(string s)
    {
        var vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u'};
        var vowelsCount = s.Count(letter => vowels.Contains(letter));
        return vowelsCount != 0;
    }
}
