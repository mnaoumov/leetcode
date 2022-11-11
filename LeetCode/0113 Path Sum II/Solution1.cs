using JetBrains.Annotations;
#pragma warning disable CS8767

namespace LeetCode._0113_Path_Sum_II;

/// <summary>
/// https://leetcode.com/problems/path-sum-ii/submissions/834083699/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        return Enumerate(root, targetSum).ToArray();
    }

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
