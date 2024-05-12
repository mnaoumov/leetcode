using JetBrains.Annotations;

namespace LeetCode.Problems._0298_Binary_Tree_Longest_Consecutive_Sequence;

/// <summary>
/// https://leetcode.com/submissions/detail/1072271792/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestConsecutive(TreeNode root)
    {
        var ans = 1;
        ans = ProcessChild(ans, root, root.left);
        ans = ProcessChild(ans, root, root.right);
        return ans;
    }

    private int ProcessChild(int ans, TreeNode node, TreeNode? child) => child == null
        ? ans
        : Math.Max(ans, LongestConsecutive(child) + (child.val == node.val + 1 ? 1 : 0));
}
