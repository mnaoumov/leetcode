using JetBrains.Annotations;

namespace LeetCode._0101_Symmetric_Tree;

/// <summary>
/// Iterative
/// https://leetcode.com/submissions/detail/829679799/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool IsSymmetric(TreeNode root)
    {
        var leftQueue = new Queue<TreeNode?>();
        var rightQueue = new Queue<TreeNode?>();

        leftQueue.Enqueue(root.left);
        rightQueue.Enqueue(root.right);

        while (leftQueue.Count > 0)
        {
            var left = leftQueue.Dequeue();
            var right = rightQueue.Dequeue();

            if (left == null || right == null)
            {
                if (left == null && right == null)
                {
                    continue;
                }

                return false;
            }

            if (left.val != right.val)
            {
                return false;
            }

            leftQueue.Enqueue(left.left);
            leftQueue.Enqueue(left.right);
            rightQueue.Enqueue(right.right);
            rightQueue.Enqueue(right.left);
        }

        return true;
    }
}
