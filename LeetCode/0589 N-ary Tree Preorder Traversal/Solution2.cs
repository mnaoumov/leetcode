using JetBrains.Annotations;

namespace LeetCode._0589_N_ary_Tree_Preorder_Traversal;

/// <summary>
/// https://leetcode.com/submissions/detail/925631631/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<int> Preorder(Node? root)
    {
        var result = new List<int>();
        var stack = new Stack<Node>();

        if (root != null)
        {
            stack.Push(root);
        }

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            result.Add(node.val);

            if (node.children == null)
            {
                continue;
            }

            foreach (var child in node.children.Reverse())
            {
                stack.Push(child);
            }
        }

        return result;
    }
}