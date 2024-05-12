using JetBrains.Annotations;

namespace LeetCode.Problems._0701_Insert_into_a_Binary_Search_Tree;

[PublicAPI]
public interface ISolution
{
    public TreeNode InsertIntoBST(TreeNode? root, int val);
}
