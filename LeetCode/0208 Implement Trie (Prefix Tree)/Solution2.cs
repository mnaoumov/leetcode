using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0208_Implement_Trie__Prefix_Tree_;

/// <summary>
/// https://leetcode.com/submissions/detail/197129416/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ITrie Create()
    {
        return new Trie2();
    }
}