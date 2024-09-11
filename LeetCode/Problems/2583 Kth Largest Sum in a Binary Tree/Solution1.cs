using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2583_Kth_Largest_Sum_in_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-335/submissions/detail/909228257/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long KthLargestLevelSum(TreeNode root, int k)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var levelSumsMinHeap = new PriorityQueue<long, long>();

        int count;

        while ((count = queue.Count) > 0)
        {
            var levelSum = 0L;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                levelSum += node.val;

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            levelSumsMinHeap.Enqueue(levelSum, levelSum);

            if (levelSumsMinHeap.Count == k + 1)
            {
                levelSumsMinHeap.Dequeue();
            }
        }

        return levelSumsMinHeap.Count != k ? -1 : levelSumsMinHeap.Peek();
    }
}
