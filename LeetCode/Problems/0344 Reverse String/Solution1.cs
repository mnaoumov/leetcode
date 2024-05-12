using JetBrains.Annotations;

namespace LeetCode._0344_Reverse_String;

/// <summary>
/// https://leetcode.com/submissions/detail/854885639/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void ReverseString(char[] s)
    {
        for (var i = 0; i < s.Length / 2; i++)
        {
            (s[i], s[^(i + 1)]) = (s[^(i + 1)], s[i]);
        }
    }
}
