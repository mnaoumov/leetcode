namespace LeetCode.Problems._2458_Height_of_Binary_Tree_After_Subtree_Removal_Queries;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-317/submissions/detail/833094795/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution01 : ISolution
{
    public int[] TreeQueries(TreeNode root, int[] queries) => queries.Select(query => GetHeight(root, query)).ToArray();

    private static int GetHeight(TreeNode node, int valueToSkip)
    {
        var childNodes = new[] { node.left, node.right }.OfType<TreeNode>().Where(x => x.val != valueToSkip).ToArray();

        if (childNodes.Length == 0)
        {
            return 0;
        }

        return 1 + childNodes.Select(childNode => GetHeight(childNode, valueToSkip)).Max();

    }
}
