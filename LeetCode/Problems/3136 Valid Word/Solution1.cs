using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace LeetCode._3136_Valid_Word;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-396/submissions/detail/1249534052/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsValid(string word) => Regex.IsMatch(word, "^[0-9A-Za-z]{3,}$") &&
                                        Regex.IsMatch(word, "(?i)[aeiou]") &&
                                        Regex.IsMatch(word, "(?i)(?![aeiou])[a-z]");
}
