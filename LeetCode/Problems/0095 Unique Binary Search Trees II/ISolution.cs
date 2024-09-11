using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0095_Unique_Binary_Search_Trees_II;

[PublicAPI]
public interface ISolution
{
    public IList<TreeNode> GenerateTrees(int n);
}
