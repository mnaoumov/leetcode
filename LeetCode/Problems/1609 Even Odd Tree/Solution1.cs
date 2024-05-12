using JetBrains.Annotations;

namespace LeetCode.Problems._1609_Even_Odd_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/905688831/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsEvenOddTree(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var isEvenLevel = true;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            var previousValue = 0;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                var isEvenValue = node.val % 2 == 0;

                if (isEvenValue == isEvenLevel)
                {
                    return false;
                }

                if (i > 0)
                {
                    if (isEvenLevel)
                    {
                        if (node.val <= previousValue)
                        {
                            return false;
                        }
                    }
                    else if (node.val >= previousValue)
                    {
                        return false;
                    }
                }

                previousValue = node.val;

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            isEvenLevel = !isEvenLevel;
        }

        return true;
    }
}
