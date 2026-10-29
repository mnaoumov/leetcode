namespace LeetCode.Problems._0387_First_Unique_Character_in_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/923042050/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FirstUniqChar(string s)
    {
        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        for (var index = 0; index < s.Length; index++)
        {
            var letter = s[index];

            if (counts[letter] == 1)
            {
                return index;
            }
        }

        return -1;
    }
}
