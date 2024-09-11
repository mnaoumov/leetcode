using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0298_Binary_Tree_Longest_Consecutive_Sequence;

/// <summary>
/// https://leetcode.com/submissions/detail/1072284180/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestConsecutive(TreeNode root) => Process(root).longestPathLength;

    private static (int longestPathLength, int longestRootedPathLength) Process(TreeNode? node)
    {
        if (node == null)
        {
            return (0, 0);
        }

        var ans = (longestPathLength: 1, longestRootedPathLength: 1);

        ProcessChild(node.left);
        ProcessChild(node.right);
        ans.longestPathLength = Math.Max(ans.longestPathLength, ans.longestRootedPathLength);
        return ans;

        void ProcessChild(TreeNode? child)
        {
            if (child == null)
            {
                return;
            }

#pragma warning disable IDE0042
            var childResult = Process(child);
#pragma warning restore IDE0042
            ans.longestPathLength = Math.Max(ans.longestPathLength, childResult.longestPathLength);

            if (child.val == node.val + 1)
            {
                ans.longestRootedPathLength = Math.Max(ans.longestRootedPathLength, childResult.longestRootedPathLength + 1);
            }
        }
    }
}
