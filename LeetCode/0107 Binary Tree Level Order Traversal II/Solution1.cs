using JetBrains.Annotations;

namespace LeetCode._0107_Binary_Tree_Level_Order_Traversal_II;

/// <summary>
/// https://leetcode.com/submissions/detail/830114354/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> LevelOrderBottom(TreeNode? root)
    {
        var result =new List<IList<int>>();
        var currentLevelNodes = new List<TreeNode?> { root };

        while (currentLevelNodes.Any())
        {
            var currentLevelValues = new List<int>();
            var nextLevelNodes = new List<TreeNode?>();

            foreach (var currentLevelNode in currentLevelNodes.OfType<TreeNode>())
            {
                currentLevelValues.Add(currentLevelNode.val);
                nextLevelNodes.Add(currentLevelNode.left);
                nextLevelNodes.Add(currentLevelNode.right);
            }

            if (currentLevelValues.Any())
            {
                result.Insert(0, currentLevelValues);
            }

            currentLevelNodes = nextLevelNodes;
        }

        return result;
    }
}