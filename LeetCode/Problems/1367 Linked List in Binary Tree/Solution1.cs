using JetBrains.Annotations;

namespace LeetCode.Problems._1367_Linked_List_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/930968923/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public bool IsSubPath(ListNode head, TreeNode root) => IsSubPath2(head, root);

    private static bool IsSubPath2(ListNode? listNode, TreeNode? treeNode)
    {
        if (listNode == null)
        {
            return true;
        }

        if (treeNode == null)
        {
            return false;
        }

        var result = IsSubPath2(listNode, treeNode.left) || IsSubPath2(listNode, treeNode.right);

        if (listNode.val == treeNode.val)
        {
            result |= IsSubPath2(listNode.next, treeNode.left) || IsSubPath2(listNode.next, treeNode.right);
        }

        return result;
    }
}
