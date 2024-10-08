namespace LeetCode.Problems._0113_Path_Sum_II;

/// <summary>
/// https://leetcode.com/submissions/detail/834085512/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> PathSum(TreeNode? root, int targetSum) => root == null ? new List<IList<int>>() : Enumerate(root, targetSum).ToArray();

    private static IEnumerable<IList<int>> Enumerate(TreeNode node, int sum)
    {
        if (node.left == null && node.right == null)
        {
            if (node.val == sum)
            {
                yield return new List<int> { node.val };
            }

            yield break;
        }

        foreach (var childNode in new[] { node.left, node.right }.OfType<TreeNode>())
        {
            foreach (var childPath in Enumerate(childNode, sum - node.val))
            {
                childPath.Insert(0, node.val);
                yield return childPath;
            }
        }
    }
}
