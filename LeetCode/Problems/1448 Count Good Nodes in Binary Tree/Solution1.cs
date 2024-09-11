using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1448_Count_Good_Nodes_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/904380951/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GoodNodes(TreeNode root) => CountGoodNodes(root, int.MinValue);

    private static int CountGoodNodes(TreeNode? node, int maxValue) =>
        node == null
            ? 0
            : (node.val >= maxValue ? 1 : 0) +
              CountGoodNodes(node.left, Math.Max(maxValue, node.val)) +
              CountGoodNodes(node.right, Math.Max(maxValue, node.val));
}
