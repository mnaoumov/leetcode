using JetBrains.Annotations;

namespace LeetCode._0429_N_ary_Tree_Level_Order_Traversal;

/// <summary>
/// https://leetcode.com/submissions/detail/935088822/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> LevelOrder(Node? root)
    {
        var result = new List<IList<int>>();

        var queue = new Queue<Node>();

        if (root != null)
        {
            queue.Enqueue(root);
        }

        while (queue.Count > 0)
        {
            var count = queue.Count;
            var list = new List<int>();

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                list.Add(node.val);

                foreach (var child in node.children ?? new List<Node>())
                {
                    queue.Enqueue(child);
                }
            }

            result.Add(list);
        }

        return result;
    }
}
