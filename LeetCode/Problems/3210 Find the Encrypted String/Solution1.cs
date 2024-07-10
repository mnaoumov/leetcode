using JetBrains.Annotations;

namespace LeetCode.Problems._3210_Find_the_Encrypted_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-405/submissions/detail/1312265275/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string GetEncryptedString(string s, int k)
    {
        k %= s.Length;
        return s[k..] + s[..k];
    }
}
