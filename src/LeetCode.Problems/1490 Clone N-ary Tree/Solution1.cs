namespace LeetCode.Problems._1490_Clone_N_ary_Tree;

/// <summary>
/// https://leetcode.com/problems/clone-n-ary-tree/submissions/2051645734/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public Node CloneTree(Node root) => new(root.val, root.children.Select(CloneTree).ToList());
}
