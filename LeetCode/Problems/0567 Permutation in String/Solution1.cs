using JetBrains.Annotations;

namespace LeetCode._0567_Permutation_in_String;

/// <summary>
/// https://leetcode.com/submissions/detail/891012371/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckInclusion(string s1, string s2)
    {
        var n1 = s1.Length;
        var n2 = s2.Length;

        if (n2 < n1)
        {
            return false;
        }

        var letterCounts1 = s1.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        var diffWindowLetterCounts = letterCounts1.ToDictionary(kvp => kvp.Key, kvp => -kvp.Value);

        for (var i = 0; i < n2; i++)
        {
            var newLetter = s2[i];
            diffWindowLetterCounts[newLetter] = diffWindowLetterCounts.GetValueOrDefault(newLetter) + 1;

            if (diffWindowLetterCounts[newLetter] == 0)
            {
                diffWindowLetterCounts.Remove(newLetter);
            }

            if (i >= n1)
            {
                var letterToRemove = s2[i - n1];
                diffWindowLetterCounts[letterToRemove] = diffWindowLetterCounts.GetValueOrDefault(letterToRemove) - 1;
                if (diffWindowLetterCounts[letterToRemove] == 0)
                {
                    diffWindowLetterCounts.Remove(letterToRemove);
                }
            }

            if (diffWindowLetterCounts.Count == 0)
            {
                return true;
            }
        }

        return false;
    }
}
