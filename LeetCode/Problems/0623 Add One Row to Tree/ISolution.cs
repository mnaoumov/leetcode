using JetBrains.Annotations;

namespace LeetCode._0623_Add_One_Row_to_Tree;

[PublicAPI]
public interface ISolution
{
    public TreeNode AddOneRow(TreeNode root, int val, int depth);
}
