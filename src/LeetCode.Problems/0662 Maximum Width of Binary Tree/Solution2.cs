namespace LeetCode.Problems._0662_Maximum_Width_of_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/936637132/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    public int WidthOfBinaryTree(TreeNode root)
    {
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(root);

        var result = 0;

        int count;

        while ((count = queue.Count) > 0)
        {
            const int notSet = -1;
            var firstNotNullIndex = notSet;
            var lastNotNullIndex = notSet;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    if (firstNotNullIndex != notSet)
                    {
                        queue.Enqueue(null);
                        queue.Enqueue(null);
                    }

                    continue;
                }

                if (firstNotNullIndex == notSet)
                {
                    firstNotNullIndex = i;
                }

                lastNotNullIndex = i;

                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            result = Math.Max(result, lastNotNullIndex - firstNotNullIndex + 1);
        }

        return result;
    }
}
