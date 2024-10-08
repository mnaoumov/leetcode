

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0623_Add_One_Row_to_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/815490262/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        var fakeRoot = new TreeNode
        {
            left = root
        };

        ProcessDepth(fakeRoot, 0);

        void ProcessDepth(TreeNode? node, int currentDepth)
        {
            if (node == null)
            {
                return;
            }

            if (currentDepth == depth - 1)
            {
                node.left = new TreeNode
                {
                    val = val,
                    left = node.left
                };
                node.right = new TreeNode
                {
                    val = val,
                    right = node.right
                };
                return;
            }

            ProcessDepth(node.left, currentDepth + 1);
            ProcessDepth(node.right, currentDepth + 1);
        }

        return fakeRoot.left;
    }
}
