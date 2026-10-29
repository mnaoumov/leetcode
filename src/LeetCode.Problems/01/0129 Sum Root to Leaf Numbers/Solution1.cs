namespace LeetCode.Problems._0129_Sum_Root_to_Leaf_Numbers;

/// <summary>
/// https://leetcode.com/problems/sum-root-to-leaf-numbers/submissions/836547257/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumNumbers(TreeNode root)
    {
        var queue = new Queue<(TreeNode? node, int parentNumber)>();
        queue.Enqueue((root, 0));
        var result = 0;

        while (queue.Count > 0)
        {
            var (node, parentNumber) = queue.Dequeue();

            if (node == null)
            {
                continue;
            }

            var number = parentNumber * 10 + node.val;

            if (node.left == null && node.right == null)
            {
                result += number;
                continue;
            }

            queue.Enqueue((node.left, number));
            queue.Enqueue((node.right, number));
        }

        return result;
    }
}
