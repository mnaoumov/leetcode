using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0623_Add_One_Row_to_Tree;

[PublicAPI]
public interface ISolution
{
    public TreeNode AddOneRow(TreeNode root, int val, int depth);
}
