using JetBrains.Annotations;

namespace LeetCode.Problems._0117_Populating_Next_Right_Pointers_in_Each_Node_II;

/// <summary>
/// https://leetcode.com/submissions/detail/934990656/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public Node? Connect(Node? root)
    {
        var node = root;

        while (node != null)
        {
            var next = node.next;
            Node? childrenLevelNext = null;

            while (childrenLevelNext == null && next != null)
            {
                childrenLevelNext = next.left ?? next.right;
                next = next.next;
            }

            if (node.right != null)
            {
                node.right.next = childrenLevelNext;

                if (node.left != null)
                {
                    node.left.next = node.right;
                }
            }
            else if (node.left != null)
            {
                node.left.next = childrenLevelNext;
            }

            Connect(node.right);
            node = node.left;
        }

        return root;
    }
}
