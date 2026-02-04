namespace LeetCode.Problems._1110_Delete_Nodes_And_Return_Forest;

[PublicAPI]
public interface ISolution
{
    // ReSharper disable once InconsistentNaming
    IList<TreeNode> DelNodes(TreeNode? root, int[] to_delete);
}
