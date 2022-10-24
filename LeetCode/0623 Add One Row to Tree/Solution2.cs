using JetBrains.Annotations;

namespace LeetCode._0623_Add_One_Row_to_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/829092687/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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
            while (true)
            {
                if (node == null)
                {
                    return;
                }

                if (currentDepth == depth - 1)
                {
                    node.left = new TreeNode { val = val, left = node.left };
                    node.right = new TreeNode { val = val, right = node.right };
                    return;
                }

                ProcessDepth(node.left, currentDepth + 1);
                node = node.right;
                currentDepth++;
            }
        }

        return fakeRoot.left;
    }
}