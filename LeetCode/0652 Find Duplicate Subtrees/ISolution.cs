using JetBrains.Annotations;

namespace LeetCode._0652_Find_Duplicate_Subtrees;

[PublicAPI]
public interface ISolution
{
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root);
}
