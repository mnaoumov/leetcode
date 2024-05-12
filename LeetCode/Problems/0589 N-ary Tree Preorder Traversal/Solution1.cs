using JetBrains.Annotations;

namespace LeetCode._0589_N_ary_Tree_Preorder_Traversal;

/// <summary>
/// https://leetcode.com/submissions/detail/925630437/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> Preorder(Node? root)
    {
        var result = new List<int>();
        Process(root);
        return result;

        void Process(Node? node)
        {
            if (node == null)
            {
                return;
            }

            result.Add(node.val);

            if (node.children == null)
            {
                return;
            }

            foreach (var child in node.children)
            {
                Process(child);
            }
        }
    }
}
