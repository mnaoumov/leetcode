using JetBrains.Annotations;

namespace LeetCode._0958_Check_Completeness_of_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/915355438/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsCompleteTree(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var fullLevelCount = 1;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            var isLastLevel = count < fullLevelCount;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                if (!CheckChildNode(node.left) || !CheckChildNode(node.right))
                {
                    return false;
                }
            }

            fullLevelCount *= 2;
            continue;

            bool CheckChildNode(TreeNode? childNode)
            {
                if (childNode != null)
                {
                    if (isLastLevel)
                    {
                        return false;
                    }

                    queue.Enqueue(childNode);
                }
                else
                {
                    isLastLevel = true;
                }

                return true;
            }
        }

        return true;
    }
}
