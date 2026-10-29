namespace LeetCode.Problems._0314_Binary_Tree_Vertical_Order_Traversal;

/// <summary>
/// https://leetcode.com/problems/binary-tree-vertical-order-traversal/submissions/1721216331/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> VerticalOrder(TreeNode root)
    {
        var columnNumbersMap = new Dictionary<int, List<int>>();

        var queue = new Queue<(TreeNode? node, int columnIndex)>();
        queue.Enqueue((root, 0));

        while (queue.Count > 0)
        {
            var (node, columnIndex) = queue.Dequeue();
            if (node == null)
            {
                continue;
            }
            if (!columnNumbersMap.ContainsKey(columnIndex))
            {
                columnNumbersMap[columnIndex] = new List<int>();
            }

            columnNumbersMap.TryAdd(columnIndex, new List<int>());
            columnNumbersMap[columnIndex].Add(node.val);
            queue.Enqueue((node.left, columnIndex - 1));
            queue.Enqueue((node.right, columnIndex + 1));
        }

        return columnNumbersMap.OrderBy(kvp => kvp.Key)
            .Select(kvp => kvp.Value)
            .ToList<IList<int>>();
    }
}
