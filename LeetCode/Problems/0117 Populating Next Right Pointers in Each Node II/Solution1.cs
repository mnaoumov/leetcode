using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0117_Populating_Next_Right_Pointers_in_Each_Node_II;

/// <summary>
/// https://leetcode.com/submissions/detail/834408281/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public Node? Connect(Node? root)
    {
        var node = root;

        while (node != null)
        {
            if (node.left != null)
            {
                node.left.next = node.right;
            }

            if (node.right != null && node.next != null)
            {
                node.right.next = node.next.left ?? node.next.right;
            }

            Connect(node.left);
            node = node.right;
        }

        return root;
    }
}
