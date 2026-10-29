namespace LeetCode.Problems._0513_Find_Bottom_Left_Tree_Value;

/// <summary>
/// https://leetcode.com/submissions/detail/1188867854/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindBottomLeftValue(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var ans = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                if (i == 0)
                {
                    ans = node.val;
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

        return ans;
    }
}
