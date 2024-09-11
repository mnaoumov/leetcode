namespace LeetCode.Problems._1302_Deepest_Leaves_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/897377077/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DeepestLeavesSum(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var result = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            result = 0;
            var isDeepestLevel = true;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    isDeepestLevel = false;
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    isDeepestLevel = false;
                }

                if (isDeepestLevel)
                {
                    result += node.val;
                }
            }
        }

        return result;
    }
}
