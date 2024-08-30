using JetBrains.Annotations;

namespace LeetCode.Problems._0590_N_ary_Tree_Postorder_Traversal;

[PublicAPI]
public interface ISolution
{
    public IList<int> Postorder(Node? root);
}
