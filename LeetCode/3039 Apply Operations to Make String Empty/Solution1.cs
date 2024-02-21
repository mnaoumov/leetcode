using System.Text;
using JetBrains.Annotations;

namespace LeetCode._3039_Apply_Operations_to_Make_String_Empty;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-124/submissions/detail/1177884182/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string LastNonEmptyString(string s)
    {
        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        var maxCount = counts.Values.Max();

        var sb = new StringBuilder();
        var usedLetters = new HashSet<char>();

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var letter = s[i];

            if (counts[letter] == maxCount && usedLetters.Add(letter))
            {
                sb.Insert(0, letter);
            }
        }

        return sb.ToString();
    }
}
