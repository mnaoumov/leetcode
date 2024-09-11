using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0617_Merge_Two_Binary_Trees;

[PublicAPI]
public interface ISolution
{
    public TreeNode? MergeTrees(TreeNode? root1, TreeNode? root2);
}
