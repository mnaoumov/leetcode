using JetBrains.Annotations;

namespace LeetCode.Problems._0637_Average_of_Levels_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/905680072/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<double> AverageOfLevels(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var result = new List<double>();

        while (queue.Count > 0)
        {
            var count = queue.Count;
            var sum = 0.0;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                sum += node.val;

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(sum / count);
        }

        return result;
    }
}
