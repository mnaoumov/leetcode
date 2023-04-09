using JetBrains.Annotations;

namespace LeetCode._1367_Linked_List_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/930975942/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public bool IsSubPath(ListNode head, TreeNode root)
    {
        return IsSubPath2(head, root);

        bool IsSubPath2(ListNode? listNode, TreeNode? treeNode)
        {
            if (listNode == null)
            {
                return true;
            }

            if (treeNode == null)
            {
                return false;
            }

            var isSubPathStarted = !ReferenceEquals(listNode, head);

            return (!isSubPathStarted || listNode.val == treeNode.val)
                   && (IsSubPath2(listNode.next, treeNode.left)
                       || IsSubPath2(listNode.next, treeNode.right)
                       || !isSubPathStarted
                       && (IsSubPath2(head, treeNode.left)
                           || IsSubPath2(head, treeNode.right)));
        }
    }

}
