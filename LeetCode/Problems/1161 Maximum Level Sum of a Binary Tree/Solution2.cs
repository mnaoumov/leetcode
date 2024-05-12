using JetBrains.Annotations;

namespace LeetCode._1161_Maximum_Level_Sum_of_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/905677744/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxLevelSum(TreeNode root)
    {
        var result = 0;
        var maxSum = 0;

        var level = 1;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var count = queue.Count;

            var levelSum = 0;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                levelSum += node.val;

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            if (result == 0 || levelSum > maxSum)
            {
                maxSum = levelSum;
                result = level;
            }

            level++;
        }

        return result;
    }
}
