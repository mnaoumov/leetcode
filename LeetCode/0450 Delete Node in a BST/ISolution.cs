using JetBrains.Annotations;

namespace LeetCode._0450_Delete_Node_in_a_BST;

[PublicAPI]
public interface ISolution
{
    public TreeNode? DeleteNode(TreeNode? root, int key);
}
