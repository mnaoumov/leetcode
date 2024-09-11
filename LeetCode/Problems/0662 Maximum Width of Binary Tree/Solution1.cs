using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0662_Maximum_Width_of_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/936636554/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
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

            if (firstNotNullIndex == notSet)
            {
                break;
            }

            var levelNodeCount = lastNotNullIndex - firstNotNullIndex + 1;

            if (levelNodeCount >= 2)
            {
                result = Math.Max(result, levelNodeCount);
            }
        }

        return result;
    }
}
