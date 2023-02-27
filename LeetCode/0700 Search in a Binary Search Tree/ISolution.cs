using JetBrains.Annotations;

namespace LeetCode._0700_Search_in_a_Binary_Search_Tree;

[PublicAPI]
public interface ISolution
{
    public TreeNode? SearchBST(TreeNode root, int val);
}
