using JetBrains.Annotations;

namespace LeetCode._0549_Binary_Tree_Longest_Consecutive_Sequence_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1072907826/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestConsecutive(TreeNode root) => Process(root).longestConsecutiveLength;

    private static (int longestConsecutiveLength, int longestIncreasingRootLength, int longestDecreasingRootLength) Process(TreeNode node)
    {
        var ans = (longestConsecutiveLength: 1, longestIncreasingRootLength: 1, longestDecreasingRootLength: 1);

        var min = node.left;
        var max = node.right;

        if (min != null && max != null && min.val > max.val)
        {
            (min, max) = (max, min);
        }

        ans = ProcessChild(min);
        ans = ProcessChild(max);

        if (min?.val == node.val - 1 && max?.val == node.val + 1)
        {
            ans.longestConsecutiveLength = Math.Max(ans.longestConsecutiveLength,
                1 + Process(min).longestDecreasingRootLength + Process(max).longestIncreasingRootLength);
        }

        return ans;

        (int longestConsecutiveLength, int longestIncreasingRootLength, int longestDecreasingRootLength) ProcessChild(TreeNode? child)
        {
            if (child == null)
            {
                return ans;
            }

#pragma warning disable IDE0042
            var childResult = Process(child);
#pragma warning restore IDE0042

            ans.longestConsecutiveLength = Math.Max(ans.longestConsecutiveLength, childResult.longestConsecutiveLength);

            if (child.val == node.val - 1)
            {
                ans.longestDecreasingRootLength =
                    Math.Max(ans.longestDecreasingRootLength, 1 + childResult.longestDecreasingRootLength);
                ans.longestConsecutiveLength = Math.Max(ans.longestConsecutiveLength, ans.longestDecreasingRootLength);
            }

            // ReSharper disable once InvertIf
            if (child.val == node.val + 1)
            {
                ans.longestIncreasingRootLength =
                    Math.Max(ans.longestIncreasingRootLength, 1 + childResult.longestIncreasingRootLength);
                ans.longestConsecutiveLength = Math.Max(ans.longestConsecutiveLength, ans.longestIncreasingRootLength);
            }

            return ans;
        }
    }
}
