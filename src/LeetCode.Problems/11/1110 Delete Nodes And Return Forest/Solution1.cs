namespace LeetCode.Problems._1110_Delete_Nodes_And_Return_Forest;

/// <summary>
/// https://leetcode.com/submissions/detail/1323510146/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    // ReSharper disable once InconsistentNaming
    public IList<TreeNode> DelNodes(TreeNode? root, int[] to_delete)
    {
        return Remove(root, true).forest;

        (TreeNode? node, IList<TreeNode> forest) Remove(TreeNode? node, bool shouldIncludeNode = false)
        {
            if (node == null)
            {
                return (null, new List<TreeNode>());
            }

            var shouldRemoveNode = to_delete.Contains(node.val);

            var (left, leftForest) = Remove(node.left, shouldRemoveNode);
            var (right, rightForest) = Remove(node.right, shouldRemoveNode);
            var forest = leftForest.Concat(rightForest).ToList();

            var convertedNode = !shouldRemoveNode ? new TreeNode(node.val, left, right) : null;

            if (shouldIncludeNode && convertedNode != null)
            {
                forest.Insert(0, convertedNode);
            }

            return (convertedNode, forest);
        }
    }
}
