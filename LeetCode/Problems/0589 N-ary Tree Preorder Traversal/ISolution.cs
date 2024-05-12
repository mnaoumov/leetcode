using JetBrains.Annotations;

namespace LeetCode._0589_N_ary_Tree_Preorder_Traversal;

[PublicAPI]
public interface ISolution
{
    public IList<int> Preorder(Node? root);
}
