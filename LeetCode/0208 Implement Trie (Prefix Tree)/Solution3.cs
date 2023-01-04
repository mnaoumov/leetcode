using JetBrains.Annotations;

namespace LeetCode._0208_Implement_Trie__Prefix_Tree_;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ITrie Create()
    {
        return new Trie3();
    }
}