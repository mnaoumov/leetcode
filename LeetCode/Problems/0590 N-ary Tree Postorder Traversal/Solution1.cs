using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0590_N_ary_Tree_Postorder_Traversal;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> Postorder(Node? root)
    {
        var list = new List<int>();
        Postorder(root, list);
        return list;
    }

    private static void Postorder(Node? node, List<int> list)
    {
        if (node == null)
        {
            return;
        }

        foreach (var child in node.children)
        {
            Postorder(child, list);
        }

        list.Add(node.val);
    }
}
