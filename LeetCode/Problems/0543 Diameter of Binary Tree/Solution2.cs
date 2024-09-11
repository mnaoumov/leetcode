using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0543_Diameter_of_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/882872935/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        var result = 0;

        Dfs(root);

        return result;

        int Dfs(TreeNode? node)
        {
            if (node == null)
            {
                return -1;
            }

            var leftMaxPath = Dfs(node.left);
            var rightMaxPath = Dfs(node.right);

            result = Math.Max(result, 2 + leftMaxPath + rightMaxPath);

            return 1 + Math.Max(leftMaxPath, rightMaxPath);
        }
    }
}
