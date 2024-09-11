using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0515_Find_Largest_Value_in_Each_Tree_Row;

[PublicAPI]
public interface ISolution
{
    public IList<int> LargestValues(TreeNode? root);
}
