using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0515_Find_Largest_Value_in_Each_Tree_Row;

/// <summary>
/// https://leetcode.com/submissions/detail/904385261/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> LargestValues(TreeNode? root)
    {
        if (root == null)
        {
            return Array.Empty<int>();
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var result = new List<int>();

        while (queue.Count > 0)
        {
            var count = queue.Count;

            var max = int.MinValue;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                max = Math.Max(max, node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(max);
        }

        return result;
    }
}
