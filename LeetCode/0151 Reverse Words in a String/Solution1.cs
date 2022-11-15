using JetBrains.Annotations;

namespace LeetCode._0151_Reverse_Words_in_a_String;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReverseWords(string s) => string.Join(" ", s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
}
