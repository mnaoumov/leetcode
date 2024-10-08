// ReSharper disable All
#pragma warning disable
#pragma warning disable
namespace LeetCode.Problems._0102_Binary_Tree_Level_Order_Traversal;

/// <summary>
/// https://leetcode.com/submissions/detail/193349968/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        var currentLevelNodes = new List<TreeNode> { root };

        while (currentLevelNodes.Any())
        {
            var nextLevelNodes = new List<TreeNode>();
            var currentLevelValues = new List<int>();
            foreach (var currentLevelNode in currentLevelNodes)
            {
                if (currentLevelNode != null)
                {
                    nextLevelNodes.Add(currentLevelNode.left);
                    nextLevelNodes.Add(currentLevelNode.right);
                    currentLevelValues.Add(currentLevelNode.val);
                }
            }

            if (currentLevelValues.Any())
            {
                result.Add(currentLevelValues);
            }

            currentLevelNodes = nextLevelNodes;
        }

        return result;
    }
}
