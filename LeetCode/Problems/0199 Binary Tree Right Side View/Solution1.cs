namespace LeetCode.Problems._0199_Binary_Tree_Right_Side_View;

/// <summary>
/// https://leetcode.com/submissions/detail/904383429/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> RightSideView(TreeNode? root)
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

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                if (i == count - 1)
                {
                    result.Add(node.val);
                }

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        return result;
    }
}
