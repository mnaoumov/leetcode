namespace LeetCode.Problems._1490_Clone_N_ary_Tree;

/// <seealso href="https://leetcode.com/problems/clone-n-ary-tree/submissions/2051648772/"/>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public Node? CloneTree(Node? root) => root == null ? null : new(root.val, root.children.Select(child => CloneTree(child)!).ToList());
}
