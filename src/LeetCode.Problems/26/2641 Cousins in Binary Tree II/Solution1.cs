using System.Numerics;

namespace LeetCode.Problems._2641_Cousins_in_Binary_Tree_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-102/submissions/detail/934191182/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        var queue = new Queue<(TreeNode node, BigInteger index)>();
        queue.Enqueue((root, 0));

        int count;
        while ((count = queue.Count) > 0)
        {
            var groups = new Dictionary<BigInteger, List<TreeNode>>();

            for (var i = 0; i < count; i++)
            {
                var (node, index) = queue.Dequeue();
                groups.TryAdd(index >> 1, new List<TreeNode>());
                groups[index >> 1].Add(node);

                if (node.left != null)
                {
                    queue.Enqueue((node.left, index * 2));
                }

                if (node.right != null)
                {
                    queue.Enqueue((node.right, index * 2 + 1));
                }
            }

            var groupSums = groups.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Sum(n => n.val));
            var totalSum = groupSums.Values.Sum();

            foreach (var (parent, group) in groups)
            {
                foreach (var node in group)
                {
                    node.val = totalSum - groupSums[parent];
                }
            }
        }

        return root;
    }
}
