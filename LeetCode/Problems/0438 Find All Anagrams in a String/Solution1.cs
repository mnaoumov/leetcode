using JetBrains.Annotations;

namespace LeetCode.Problems._0438_Find_All_Anagrams_in_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/891650877/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var letterCountsP = p.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        var result = new List<int>();
        var letterCountsDiff = letterCountsP.ToDictionary(kvp => kvp.Key, kvp => -kvp.Value);

        for (var i = 0; i < s.Length; i++)
        {
            var newLetter = s[i];
            letterCountsDiff[newLetter] = letterCountsDiff.GetValueOrDefault(newLetter) + 1;
            if (letterCountsDiff[newLetter] == 0)
            {
                letterCountsDiff.Remove(newLetter);
            }

            if (i >= p.Length)
            {
                var oldLetter = s[i - p.Length];
                letterCountsDiff[oldLetter] = letterCountsDiff.GetValueOrDefault(oldLetter) - 1;

                if (letterCountsDiff[oldLetter] == 0)
                {
                    letterCountsDiff.Remove(oldLetter);
                }
            }

            if (i >= p.Length - 1 && !letterCountsDiff.Any())
            {
                result.Add(i - p.Length + 1);
            }
        }

        return result;
    }
}
