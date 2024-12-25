namespace LeetCode.Problems._2415_Reverse_Odd_Levels_of_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1483835257/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        var ans = new TreeNode(root.val);

        var parentDirectNodes = new List<TreeNode> { root };
        var parentReverseNodes = new List<TreeNode> { ans };

        var isOddLevel = false;

        while (true)
        {
            isOddLevel = !isOddLevel;
            var directNodes = new List<TreeNode>();

            foreach (var parentDirectNode in parentDirectNodes)
            {
                if (parentDirectNode.left != null)
                {
                    directNodes.Add(parentDirectNode.left);
                }

                if (parentDirectNode.right != null)
                {
                    directNodes.Add(parentDirectNode.right);
                }
            }

            if (directNodes.Count == 0)
            {
                break;
            }

            var reverseNodes = new List<TreeNode>();

            for (var i = 0; i < parentReverseNodes.Count; i++)
            {
                var parentReverseNode = parentReverseNodes[i];
                var matchingDirectNode = isOddLevel ? parentDirectNodes[^(i + 1)] : parentDirectNodes[i];
                var matchingLeftNode = isOddLevel ? matchingDirectNode.right! : matchingDirectNode.left!;
                var matchingRightNode = isOddLevel ? matchingDirectNode.left! : matchingDirectNode.right!;
                parentReverseNode.left = new TreeNode(matchingLeftNode.val);
                parentReverseNode.right = new TreeNode(matchingRightNode.val);
                reverseNodes.Add(parentReverseNode.left);
                reverseNodes.Add(parentReverseNode.right);
            }

            parentDirectNodes = directNodes;
            parentReverseNodes = reverseNodes;
        }

        return ans;
    }
}
