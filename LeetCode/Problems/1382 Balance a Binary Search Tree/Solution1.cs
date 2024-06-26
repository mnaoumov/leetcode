using JetBrains.Annotations;

namespace LeetCode.Problems._1382_Balance_a_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1300362518/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode BalanceBST(TreeNode root)
    {
        var sortedArray = InOrder(root).ToArray();
        return Balance(0, sortedArray.Length - 1)!;

        TreeNode? Balance(int left, int right)
        {
            if (left > right)
            {
                return null;
            }
            
            var mid = left + (right - left >> 1);
            return new TreeNode
            {
                val = sortedArray[mid],
                left = Balance(left, mid - 1),
                right = Balance(mid + 1, right)
            };
        }
    }

    private static IEnumerable<int> InOrder(TreeNode? node) => node == null
        ? Enumerable.Empty<int>()
        : InOrder(node.left).Append(node.val).Concat(InOrder(node.right));
}
