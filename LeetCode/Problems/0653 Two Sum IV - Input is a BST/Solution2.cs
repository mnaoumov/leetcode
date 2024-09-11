using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0653_Two_Sum_IV___Input_is_a_BST;

/// <summary>
/// https://leetcode.com/submissions/detail/829090816/
/// https://leetcode.com/submissions/detail/829090909/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool FindTarget(TreeNode root, int k)
    {
        return FindNode(root);

        bool FindNode(TreeNode? node)
        {
            if (node == null)
            {
                return false;
            }

            if (FindValue(root, k - node.val, node))
            {
                return true;
            }

            return FindNode(node.left) || FindNode(node.right);
        }

        bool FindValue(TreeNode? searchNode, int value, TreeNode skipNode)
        {
            if (searchNode == null)
            {
                return false;
            }

            if (searchNode.val == value && !Equals(searchNode, skipNode))
            {
                return true;
            }

            if (value <= searchNode.val && FindValue(searchNode.left, value, skipNode))
            {
                return true;
            }

            return value >= searchNode.val && FindValue(searchNode.right, value, skipNode);
        }
    }
}
