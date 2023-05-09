using JetBrains.Annotations;

namespace LeetCode._1469_Find_All_The_Lonely_Nodes;

[PublicAPI]
public interface ISolution
{
    public IList<int> GetLonelyNodes(TreeNode root);
}
