using JetBrains.Annotations;

namespace LeetCode._2385_Amount_of_Time_for_Binary_Tree_to_Be_Infected;

/// <summary>
/// https://leetcode.com/submissions/detail/1142853780/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int AmountOfTime(TreeNode root, int start)
    {
        TreeNode? otherChild;
        var distanceFromRoot = 0;
        TreeNode? startNode;

        if (root.val == start)
        {
            otherChild = null;
            startNode = root;
        }
        else
        {
            (startNode, distanceFromRoot) = Find(root.left, start);

            if (startNode != null)
            {
                otherChild = root.right;
            }
            else
            {
                (startNode, distanceFromRoot) = Find(root.right, start);
                otherChild = root.left;
            }
        }

        return new[] { Depth(startNode) - 1, distanceFromRoot + Depth(otherChild) }.Max();
    }

    private static (TreeNode? startNode, int distanceFromRoot) Find(TreeNode? node, int start)
    {
        if (node == null)
        {
            return (null, 0);
        }

        if (node.val == start)
        {
            return (node, 1);
        }

        var (startNode, distanceFromRoot) = Find(node.left, start);

        if (startNode == null)
        {
            (startNode, distanceFromRoot) = Find(node.right, start);
        }

        return (startNode, distanceFromRoot + 1);

    }

    private static int Depth(TreeNode? node) => node == null ? 0 : 1 + Math.Max(Depth(node.left), Depth(node.right));
}
