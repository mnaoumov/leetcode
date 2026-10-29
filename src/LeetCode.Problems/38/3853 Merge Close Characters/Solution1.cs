using System.Text;

namespace LeetCode.Problems._3853_Merge_Close_Characters;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-177/problems/merge-close-characters/submissions/1933745481/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MergeCharacters(string s, int k)
    {
        var visibleLetters = new HashSet<char>();
        var skippedIndices = new HashSet<int>();

        var n = s.Length;
        var sb = new StringBuilder();

        for (var i = 0; i < n; i++)
        {
            if (sb.Length >= k + 1 && !skippedIndices.Contains(i))
            {
                var oldLetter = sb[^(k + 1)];
                visibleLetters.Remove(oldLetter);
            }

            var letter = s[i];

            if (visibleLetters.Add(letter))
            {
                sb.Append(letter);
            }
            else
            {
                skippedIndices.Add(i);
            }
        }

        return sb.ToString();
    }
}
