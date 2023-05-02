using JetBrains.Annotations;

namespace LeetCode._0208_Implement_Trie__Prefix_Tree_;

/// <summary>
/// https://leetcode.com/submissions/detail/197128931/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ITrie Create()
    {
        return new Trie1();
    }
}
