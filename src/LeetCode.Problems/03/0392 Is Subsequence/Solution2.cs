namespace LeetCode.Problems._0392_Is_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/853558382/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool IsSubsequence(string s, string t)
    {
        return Recurse(0, 0);

        bool Recurse(int sIndex, int tIndex) =>
            sIndex == s.Length || tIndex != t.Length &&
            (s[sIndex] == t[tIndex] ? Recurse(sIndex + 1, tIndex + 1) : Recurse(sIndex, tIndex + 1));
    }
}
