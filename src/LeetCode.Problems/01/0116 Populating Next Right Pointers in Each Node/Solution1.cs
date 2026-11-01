namespace LeetCode.Problems._0116_Populating_Next_Right_Pointers_in_Each_Node;

/// <seealso href="https://leetcode.com/submissions/detail/834400428/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public Node? Connect(Node? root)
    {
        var node = root;

        while (node?.left != null)
        {
            node.left.next = node.right;
            node.right!.next = node.next?.left;
            Connect(node.left);
            node = node.right;
        }

        return root;
    }
}
