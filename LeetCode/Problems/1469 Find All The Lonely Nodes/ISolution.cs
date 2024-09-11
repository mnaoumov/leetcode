using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1469_Find_All_The_Lonely_Nodes;

[PublicAPI]
public interface ISolution
{
    public IList<int> GetLonelyNodes(TreeNode root);
}
