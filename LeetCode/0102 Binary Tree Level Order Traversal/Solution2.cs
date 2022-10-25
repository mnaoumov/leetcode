using JetBrains.Annotations;

namespace LeetCode._0102_Binary_Tree_Level_Order_Traversal;

/// <summary>
/// https://leetcode.com/submissions/detail/829698036/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> LevelOrder(TreeNode? root)
    {
        var result = new List<IList<int>>();

        var queue = new Queue<TreeNode?>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var count = queue.Count;
            List<int>? levelValues = null;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    continue;
                }

                if (levelValues == null)
                {
                    levelValues = new List<int>();
                    result.Add(levelValues);
                }

                levelValues.Add(node.val);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }

        return result;
    }
}