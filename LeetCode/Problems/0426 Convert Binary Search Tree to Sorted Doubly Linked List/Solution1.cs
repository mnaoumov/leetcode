namespace LeetCode.Problems._0426_Convert_Binary_Search_Tree_to_Sorted_Doubly_Linked_List;

/// <summary>
/// https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/submissions/1679811088/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public Node TreeToDoublyList(Node root) => TreeToDoublyListHeadTail(root).head!;

    private static (Node? head, Node? tail) TreeToDoublyListHeadTail(Node? node)
    {
        if (node == null)
        {
            return (null, null);
        }

        var (leftHead, leftTail) = TreeToDoublyListHeadTail(node.left);
        var (rightHead, rightTail) = TreeToDoublyListHeadTail(node.right);

        node.left = leftTail;
        node.right = rightHead;

        if (leftTail != null)
        {
            leftTail.right = node;
        }

        if (rightHead != null)
        {
            rightHead.left = node;
        }

        leftHead ??= node;
        rightTail ??= node;

        leftHead.left = rightTail;
        rightTail.right = leftHead;

        return (leftHead, rightTail);
    }
}