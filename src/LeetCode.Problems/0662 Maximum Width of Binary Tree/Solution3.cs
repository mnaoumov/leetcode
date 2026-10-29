namespace LeetCode.Problems._0662_Maximum_Width_of_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/946330405/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int WidthOfBinaryTree(TreeNode root)
    {
        var queue = new Queue<(TreeNode? treeNode, int sequentialNullsCount)>();
        queue.Enqueue((treeNode: root, sequentialNullsCount: 0));

        var result = 0;

        int count;

        while ((count = queue.Count) > 0)
        {
            const int notSet = -1;
            var firstNotNullIndex = notSet;
            var lastNotNullIndex = notSet;
            var index = 0;
            var lastSequentialNullsCount = 0;

            for (var i = 0; i < count; i++)
            {
                var (treeNode, sequentialNullsCount) = queue.Dequeue();

                if (treeNode == null)
                {
                    index += sequentialNullsCount;
                    lastSequentialNullsCount += 2 * sequentialNullsCount;
                }
                else
                {
                    if (firstNotNullIndex == notSet)
                    {
                        firstNotNullIndex = index;
                    }

                    lastNotNullIndex = index;

                    UseChildNode(treeNode.left);
                    UseChildNode(treeNode.right);

                    index++;

                    void UseChildNode(TreeNode? childNode)
                    {
                        if (childNode != null)
                        {
                            if (lastSequentialNullsCount > 0)
                            {
                                queue.Enqueue((treeNode: null, sequentialNullsCount: lastSequentialNullsCount));
                                lastSequentialNullsCount = 0;
                            }

                            queue.Enqueue((treeNode: childNode, sequentialNullsCount: 0));
                        }
                        else
                        {
                            lastSequentialNullsCount++;
                        }
                    }
                }
            }

            result = Math.Max(result, lastNotNullIndex - firstNotNullIndex + 1);
        }

        return result;
    }
}
