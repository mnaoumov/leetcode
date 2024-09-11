using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1161_Maximum_Level_Sum_of_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/905676378/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxLevelSum(TreeNode root)
    {
        var result = 0;
        var maxSum = 0;

        var level = 1;
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var count = queue.Count;

            var levelSum = 0;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    continue;
                }

                levelSum += node.val;
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            if (result == 0 || levelSum > maxSum)
            {
                maxSum = levelSum;
                result = level;
            }

            level++;
        }

        return result;
    }
}
