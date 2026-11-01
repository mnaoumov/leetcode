namespace LeetCode.Problems._0590_N_ary_Tree_Postorder_Traversal;

/// <seealso href="TODO url"/>
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
