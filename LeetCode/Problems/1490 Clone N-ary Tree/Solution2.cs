namespace LeetCode.Problems._1490_Clone_N_ary_Tree;

/// <summary>
/// https://leetcode.com/problems/clone-n-ary-tree/submissions/2051648772/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public Node? CloneTree(Node? root) => root == null ? null : new(root.val, root.children.Select(child => CloneTree(child)!).ToList());
}
