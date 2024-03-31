using JetBrains.Annotations;

namespace LeetCode._1119_Remove_Vowels_from_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1211242723/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
#pragma warning disable SYSLIB1045
    public string RemoveVowels(string s) => System.Text.RegularExpressions.Regex.Replace(s, "[aeiou]", "");
#pragma warning restore SYSLIB1045
}
