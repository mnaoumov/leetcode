using JetBrains.Annotations;

namespace LeetCode.Problems._1347_Minimum_Number_of_Steps_to_Make_Two_Strings_Anagram;

/// <summary>
/// https://leetcode.com/submissions/detail/1145443355/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSteps(string s, string t)
    {
        var sLetterCounts = CountLetters(s);
        var tLetterCounts = CountLetters(t);

        var allLetters = sLetterCounts.Keys.Union(tLetterCounts.Keys);

        return allLetters.Sum(letter =>
            Math.Abs(sLetterCounts.GetValueOrDefault(letter) - tLetterCounts.GetValueOrDefault(letter))) / 2;
    }

    private static Dictionary<char, int> CountLetters(string s) =>
        s.ToCharArray().GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
}
