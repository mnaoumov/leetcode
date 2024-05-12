using JetBrains.Annotations;

namespace LeetCode.Problems._1634_Add_Two_Polynomials_Represented_as_Linked_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/946350381/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public PolyNode? AddPoly(PolyNode? poly1, PolyNode? poly2)
    {
        var fakeRoot = new PolyNode();
        var node = fakeRoot;

        var node1 = poly1;
        var node2 = poly2;

        while (true)
        {
            PolyNode? next = null;

            if (node1 == null && node2 == null)
            {
                return fakeRoot.next;
            }

            if (node1 == null || node2 != null && node2.power > node1.power)
            {
                next = new PolyNode(node2!.coefficient, node2.power);
                node2 = node2.next;
            }
            else if (node2 == null || node1.power > node2.power)
            {
                next = new PolyNode(node1.coefficient, node1.power);
                node1 = node1.next;
            }
            else
            {
                var coefficient = node1.coefficient + node2.coefficient;

                if (coefficient != 0)
                {
                    next = new PolyNode(coefficient, node1.power);
                }

                node1 = node1.next;
                node2 = node2.next;
            }

            if (next == null)
            {
                continue;
            }

            node.next = next;
            node = next;
        }
    }
}
