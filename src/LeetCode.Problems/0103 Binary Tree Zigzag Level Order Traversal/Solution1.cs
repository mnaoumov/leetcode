namespace LeetCode.Problems._0103_Binary_Tree_Zigzag_Level_Order_Traversal;

/// <summary>
/// https://leetcode.com/submissions/detail/830083326/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode? root)
    {
        var result = new List<IList<int>>();
        var isLeftToRight = true;
        var currentLevelNodes = new List<TreeNode?> { root };

        while (currentLevelNodes.Any())
        {
            var nextLevelNodes = new List<TreeNode?>();
            var currentLevelValues = new List<int>();

            foreach (var currentLevelNode in currentLevelNodes.OfType<TreeNode>())
            {
                if (isLeftToRight)
                {
                    currentLevelValues.Add(currentLevelNode.val);
                }
                else
                {
                    currentLevelValues.Insert(0, currentLevelNode.val);
                }

                nextLevelNodes.Add(currentLevelNode.left);
                nextLevelNodes.Add(currentLevelNode.right);
            }

            if (currentLevelValues.Any())
            {
                result.Add(currentLevelValues);
            }

            currentLevelNodes = nextLevelNodes;
            isLeftToRight = !isLeftToRight;
        }

        return result;
    }
}
