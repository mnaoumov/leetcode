using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0776_Split_BST;

[PublicAPI]
public interface ISolution
{
    public TreeNode?[] SplitBST(TreeNode? root, int target);
}
